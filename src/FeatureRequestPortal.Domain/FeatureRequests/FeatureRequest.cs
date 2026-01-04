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

    public virtual ICollection<Vote> Votes { get; protected set; }
    public virtual ICollection<Comment> Comments { get; protected set; }
    public virtual ICollection<Category> Categories { get; protected set; }

    protected FeatureRequest()
    {
        Votes = new Collection<Vote>();
        Comments = new Collection<Comment>();
        Categories = new Collection<Category>();
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
        Categories = new Collection<Category>();
    }
}
