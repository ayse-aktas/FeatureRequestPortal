using System;
using System.ComponentModel.DataAnnotations;

namespace FeatureRequestPortal.FeatureRequests;

public class CreateCommentDto
{
    [Required]
    public Guid FeatureRequestId { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Text { get; set; }
}
