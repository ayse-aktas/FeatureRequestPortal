using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests;

public class Category : AuditedEntity<Guid>
{
    public string Name { get; set; }

    protected Category()
    {
    }

    public Category(Guid id, string name)
        : base(id)
    {
        Name = name;
    }
}
