using System.ComponentModel.DataAnnotations;

namespace FeatureRequestPortal.FeatureRequests;

public class CreateFeatureRequestDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Description { get; set; }
}
