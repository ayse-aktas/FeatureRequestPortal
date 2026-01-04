using System;
using System.Threading.Tasks;
using FeatureRequestPortal.FeatureRequests;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace FeatureRequestPortal.Data;

public class CategoryDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Category, Guid> _categoryRepository;
    private readonly IGuidGenerator _guidGenerator;

    public CategoryDataSeedContributor(
        IRepository<Category, Guid> categoryRepository,
        IGuidGenerator guidGenerator)
    {
        _categoryRepository = categoryRepository;
        _guidGenerator = guidGenerator;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _categoryRepository.GetCountAsync() > 0)
        {
            return;
        }

        await _categoryRepository.InsertAsync(new Category(_guidGenerator.Create(), "Core"));
        await _categoryRepository.InsertAsync(new Category(_guidGenerator.Create(), "UI/UX"));
        await _categoryRepository.InsertAsync(new Category(_guidGenerator.Create(), "Backend"));
        await _categoryRepository.InsertAsync(new Category(_guidGenerator.Create(), "Mobile"));
        await _categoryRepository.InsertAsync(new Category(_guidGenerator.Create(), "Integrations"));
    }
}
