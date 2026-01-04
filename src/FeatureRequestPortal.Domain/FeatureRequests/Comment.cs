using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests;

public class Comment : CreationAuditedEntity<Guid>
{
    public Guid FeatureRequestId { get; set; }
    public string Text { get; set; }

    public Comment()
    {
    }

    public Comment(Guid id, Guid featureRequestId, string text) : base(id)
    {
        FeatureRequestId = featureRequestId;
        Text = text;
    }
}
