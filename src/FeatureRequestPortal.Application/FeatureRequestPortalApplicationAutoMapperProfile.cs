using System.Linq;
using AutoMapper;
using FeatureRequestPortal.FeatureRequests;

namespace FeatureRequestPortal;

public class FeatureRequestPortalApplicationAutoMapperProfile : Profile
{
    public FeatureRequestPortalApplicationAutoMapperProfile()
    {
        CreateMap<FeatureRequest, FeatureRequestDto>()
            .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name)));
        CreateMap<Comment, CommentDto>();
        CreateMap<Category, CategoryDto>();
    }
}
