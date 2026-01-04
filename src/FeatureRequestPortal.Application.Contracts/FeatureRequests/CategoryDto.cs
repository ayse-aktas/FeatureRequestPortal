using System;
using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests;

public class CategoryDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
