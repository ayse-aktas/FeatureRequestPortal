using AutoMapper;
using FeatureRequestPortal.FeatureRequests;

namespace FeatureRequestPortal;

public class FeatureRequestPortalApplicationAutoMapperProfile : Profile
{
    public FeatureRequestPortalApplicationAutoMapperProfile()
    {
        CreateMap<FeatureRequest, FeatureRequestDto>();
        CreateMap<Comment, CommentDto>();
    }
}
