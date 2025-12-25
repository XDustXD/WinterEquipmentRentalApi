using Microsoft.AspNetCore.Mvc;
using WinterEquipmentRentalApi.Dto.Rental;
using WinterEquipmentRentalApi.Dto.RentalReturn;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rentals = await service.GetAll();
        return Ok(rentals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var rental = await service.GetById(id);
        return Ok(rental);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRentalDto dto)
    {
        var id = await service.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateRentalDto dto)
    {
        await service.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await service.Remove(id);
        return NoContent();
    }

    [HttpPost("{id}/end")]
    public async Task<IActionResult> EndRental(string id)
    {
        var returnId = await service.EndRental(id);
        return CreatedAtAction("GetById", "RentalReturn", new { id = returnId }, null);
    }
}
