using System;
using System.Threading.Tasks;
using FeatureRequestPortal.FeatureRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Alerts;

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

    [HttpGet]
    public async Task<IActionResult> Detail(Guid id)
    {
        var featureRequest = await _featureRequestAppService.GetAsync(id);
        return View(featureRequest);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Vote(Guid id)
    {
        await _featureRequestAppService.VoteAsync(id);
        return RedirectToAction("Detail", new { id });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddComment(CreateCommentDto input)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Detail", new { id = input.FeatureRequestId });
        }

        await _featureRequestAppService.CreateCommentAsync(input);
        return RedirectToAction("Detail", new { id = input.FeatureRequestId });
    }

    [HttpPost]
    [Authorize] // Admin check would be here
    public async Task<IActionResult> UpdateStatus(Guid id, FeatureRequestStatus status)
    {
        await _featureRequestAppService.UpdateAsync(id, new UpdateFeatureRequestDto { Status = status });
        return RedirectToAction("Detail", new { id });
    }

    [HttpPost]
    [Authorize] // Admin check
    public async Task<IActionResult> Delete(Guid id)
    {
        await _featureRequestAppService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
