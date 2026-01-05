using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace FeatureRequestPortal.Data;

public class FeatureRequestPermissionDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IPermissionManager _permissionManager;

    public FeatureRequestPermissionDataSeedContributor(IPermissionManager permissionManager)
    {
        _permissionManager = permissionManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Grant "Manage" permission to the "admin" role
        // Permission string is "FeatureRequestPortal.FeatureRequests.Manage"
        await _permissionManager.SetForRoleAsync("admin", "FeatureRequestPortal.FeatureRequests.Manage", true);
    }
}
