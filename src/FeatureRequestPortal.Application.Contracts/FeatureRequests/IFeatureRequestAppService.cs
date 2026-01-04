using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FeatureRequestPortal.FeatureRequests;

public interface IFeatureRequestAppService : IApplicationService
{
    Task<FeatureRequestDto> GetAsync(Guid id);

    Task<PagedResultDto<FeatureRequestDto>> GetListAsync(FeatureRequestGetListInput input);

    Task<FeatureRequestDto> CreateAsync(CreateFeatureRequestDto input);

    Task<FeatureRequestDto> UpdateAsync(Guid id, UpdateFeatureRequestDto input);

    Task DeleteAsync(Guid id);

    Task VoteAsync(Guid id);

    Task<CommentDto> CreateCommentAsync(CreateCommentDto input);

    Task<List<CategoryDto>> GetCategoriesAsync();
}
