using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace FeatureRequestPortal.FeatureRequests;

public class FeatureRequestAppService : ApplicationService, IFeatureRequestAppService
{
    private readonly IRepository<FeatureRequest, Guid> _featureRequestRepository;
    private readonly IRepository<Vote, Guid> _voteRepository;
    private readonly IRepository<Comment, Guid> _commentRepository;
    private readonly IIdentityUserRepository _userRepository;

    public FeatureRequestAppService(
        IRepository<FeatureRequest, Guid> featureRequestRepository,
        IRepository<Vote, Guid> voteRepository,
        IRepository<Comment, Guid> commentRepository,
        IIdentityUserRepository userRepository)
    {
        _featureRequestRepository = featureRequestRepository;
        _voteRepository = voteRepository;
        _commentRepository = commentRepository;
        _userRepository = userRepository;
    }

    public async Task<FeatureRequestDto> GetAsync(Guid id)
    {
        var featureRequest = await _featureRequestRepository.GetAsync(id);
        var dto = ObjectMapper.Map<FeatureRequest, FeatureRequestDto>(featureRequest);
        
        // Fill creator names for comments
        foreach (var comment in dto.Comments)
        {
            if (comment.CreatorId.HasValue)
            {
                var user = await _userRepository.FindAsync(comment.CreatorId.Value);
                comment.CreatorName = user?.UserName ?? "Unknown";
            }
        }

        return dto;
    }

    public async Task<PagedResultDto<FeatureRequestDto>> GetListAsync(FeatureRequestGetListInput input)
    {
        var queryable = await _featureRequestRepository.GetQueryableAsync();

        queryable = queryable
            .WhereIf(input.Status.HasValue, x => x.Status == input.Status!.Value);

        var totalCount = await AsyncExecuter.CountAsync(queryable);

        var featureRequests = await AsyncExecuter.ToListAsync(
            queryable
                .OrderBy(input.Sorting ?? "CreationTime desc")
                .PageBy(input.SkipCount, input.MaxResultCount)
        );

        return new PagedResultDto<FeatureRequestDto>(
            totalCount,
            ObjectMapper.Map<List<FeatureRequest>, List<FeatureRequestDto>>(featureRequests)
        );
    }

    [Authorize]
    public async Task<FeatureRequestDto> CreateAsync(CreateFeatureRequestDto input)
    {
        var featureRequest = new FeatureRequest(
            GuidGenerator.Create(),
            input.Title,
            input.Description
        );

        await _featureRequestRepository.InsertAsync(featureRequest);

        return ObjectMapper.Map<FeatureRequest, FeatureRequestDto>(featureRequest);
    }

    [Authorize] // Admin check should be added via permission system in real world
    public async Task<FeatureRequestDto> UpdateAsync(Guid id, UpdateFeatureRequestDto input)
    {
        var featureRequest = await _featureRequestRepository.GetAsync(id);
        featureRequest.Status = input.Status;

        await _featureRequestRepository.UpdateAsync(featureRequest);

        return ObjectMapper.Map<FeatureRequest, FeatureRequestDto>(featureRequest);
    }

    [Authorize] // Admin check
    public async Task DeleteAsync(Guid id)
    {
        await _featureRequestRepository.DeleteAsync(id);
    }

    [Authorize]
    public async Task VoteAsync(Guid id)
    {
        var userId = CurrentUser.Id.GetValueOrDefault();
        
        // Check if user already voted
        var existingVote = await _voteRepository.FirstOrDefaultAsync(x => x.FeatureRequestId == id && x.CreatorId == userId);
        if (existingVote != null)
        {
            throw new Volo.Abp.UserFriendlyException("You have already voted for this feature request.");
        }

        var featureRequest = await _featureRequestRepository.GetAsync(id);
        
        var vote = new Vote(GuidGenerator.Create(), id);
        await _voteRepository.InsertAsync(vote);

        featureRequest.VoteCount++;
        await _featureRequestRepository.UpdateAsync(featureRequest);
    }

    [Authorize]
    public async Task<CommentDto> CreateCommentAsync(CreateCommentDto input)
    {
        var comment = new Comment(GuidGenerator.Create(), input.FeatureRequestId, input.Text);
        await _commentRepository.InsertAsync(comment);

        var dto = ObjectMapper.Map<Comment, CommentDto>(comment);
        var user = await _userRepository.FindAsync(CurrentUser.Id.GetValueOrDefault());
        dto.CreatorName = user?.UserName ?? "Unknown";

        return dto;
    }
}
