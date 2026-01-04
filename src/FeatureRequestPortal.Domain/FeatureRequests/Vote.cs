using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests;

public class Vote : CreationAuditedEntity<Guid>
{
    public Guid FeatureRequestId { get; set; }
    public int Value { get; set; } // +1 or -1

    public Vote()
    {
    }

    public Vote(Guid id, Guid featureRequestId, int value) : base(id)
    {
        FeatureRequestId = featureRequestId;
        Value = value;
    }
}
