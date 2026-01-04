using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FeatureRequestPortal.FeatureRequests;

public class CreateFeatureRequestDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(2000)]
    public string Description { get; set; }

    public List<Guid> CategoryIds { get; set; }
}
