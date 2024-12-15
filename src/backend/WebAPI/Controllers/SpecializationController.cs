using Application.Contracts.Services;
using Application.DTOs;
using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using WebAPI.HelpersApi.Extensions.ResultPattern;

namespace WebAPI.Controllers;

[Route("/api/specializations")]
public sealed class SpecializationController(ISpecializationService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] SpecializationFilter filter)
        => (await service.GetAllAsync(filter)).ToActionResult();

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
        => (await service.GetByIdAsync(id)).ToActionResult();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SpecializationCreateInfo entity)
        => (await service.CreateAsync(entity)).ToActionResult();

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SpecializationUpdateInfo entity)
        => (await service.UpdateAsync(id, entity)).ToActionResult();

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
        => (await service.DeleteAsync(id)).ToActionResult();
}