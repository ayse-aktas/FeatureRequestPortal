using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests;

public class Vote : CreationAuditedEntity<Guid>
{
    public Guid FeatureRequestId { get; set; }

    public Vote()
    {
    }

    public Vote(Guid id, Guid featureRequestId) : base(id)
    {
        FeatureRequestId = featureRequestId;
    }
}
