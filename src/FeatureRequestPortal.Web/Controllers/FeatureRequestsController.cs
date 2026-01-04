using System;
using System.Threading.Tasks;
using FeatureRequestPortal.FeatureRequests;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace FeatureRequestPortal.Web.Controllers;

public class FeatureRequestsController : AbpController
{
    private readonly IFeatureRequestAppService _featureRequestAppService;

    public FeatureRequestsController(IFeatureRequestAppService featureRequestAppService)
    {
        _featureRequestAppService = featureRequestAppService;
    }

    public async Task<IActionResult> Index(FeatureRequestStatus? status, string sorting)
    {
        var input = new FeatureRequestGetListInput
        {
            Status = status,
            Sorting = sorting,
            MaxResultCount = 15, // As per requirements
            SkipCount = 0 // Will add pagination logic later
        };

        var result = await _featureRequestAppService.GetListAsync(input);

        ViewBag.Status = status;
        ViewBag.Sorting = sorting;

        return View(result.Items);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateFeatureRequestDto input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        await _featureRequestAppService.CreateAsync(input);
        return RedirectToAction("Index");
    }
}
