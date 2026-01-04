using Microsoft.AspNetCore.Mvc;

namespace FeatureRequestPortal.Web.Pages;

public class IndexModel : FeatureRequestPortalPageModel
{
    public IActionResult OnGet()
    {
        return RedirectToAction("Index", "FeatureRequests");
    }
}
