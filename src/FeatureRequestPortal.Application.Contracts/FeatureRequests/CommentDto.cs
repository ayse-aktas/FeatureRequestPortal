using System;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests;

public class CommentDto : EntityDto<Guid>
{
    public Guid FeatureRequestId { get; set; }
    public string Text { get; set; }
    public Guid? CreatorId { get; set; }
    public DateTime CreationTime { get; set; }
    public string CreatorName { get; set; }
}
