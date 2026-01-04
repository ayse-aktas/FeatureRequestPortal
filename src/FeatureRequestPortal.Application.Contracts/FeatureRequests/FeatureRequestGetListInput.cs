using Volo.Abp.Application.Dtos;

namespace FeatureRequestPortal.FeatureRequests;

public class FeatureRequestGetListInput : PagedAndSortedResultRequestDto
{
    public FeatureRequestStatus? Status { get; set; }
}
