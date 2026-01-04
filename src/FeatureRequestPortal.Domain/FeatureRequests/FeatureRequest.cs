using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities.Auditing;

namespace FeatureRequestPortal.FeatureRequests;

public class FeatureRequest : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public FeatureRequestStatus Status { get; set; }
    public int VoteCount { get; set; }

    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }

    public FeatureRequest()
    {
        Votes = new Collection<Vote>();
        Comments = new Collection<Comment>();
    }

    public FeatureRequest(
        Guid id,
        string title,
        string description,
        FeatureRequestStatus status = FeatureRequestStatus.Pending) : base(id)
    {
        Title = title;
        Description = description;
        Status = status;
        VoteCount = 0;
        Votes = new Collection<Vote>();
        Comments = new Collection<Comment>();
    }
}
