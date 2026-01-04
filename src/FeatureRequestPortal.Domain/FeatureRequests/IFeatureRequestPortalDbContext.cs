using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FeatureRequestPortal.FeatureRequests;

[ConnectionStringName("Default")]
public interface IFeatureRequestPortalDbContext : IEfCoreDbContext
{
    DbSet<FeatureRequest> FeatureRequests { get; set; }
    DbSet<Vote> Votes { get; set; }
    DbSet<Comment> Comments { get; set; }
}
