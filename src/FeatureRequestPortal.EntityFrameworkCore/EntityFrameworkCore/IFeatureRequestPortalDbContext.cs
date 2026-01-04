using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using FeatureRequestPortal.FeatureRequests;

namespace FeatureRequestPortal.EntityFrameworkCore;

[ConnectionStringName("Default")]
public interface IFeatureRequestPortalDbContext : IEfCoreDbContext
{
    DbSet<FeatureRequest> FeatureRequests { get; }
    DbSet<Vote> Votes { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Category> Categories { get; }
}
