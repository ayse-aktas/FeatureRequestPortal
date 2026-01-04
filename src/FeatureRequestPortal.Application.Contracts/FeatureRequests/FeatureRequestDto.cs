using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests;

public class FeatureRequestDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public FeatureRequestStatus Status { get; set; }
    public int VoteCount { get; set; }
    public List<CommentDto> Comments { get; set; }
    public List<string> CategoryNames { get; set; }
}
