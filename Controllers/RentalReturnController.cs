using Microsoft.AspNetCore.Mvc;
using WinterEquipmentRentalApi.Dto.RentalReturn;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalReturnController(IRentalReturnService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await service.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await service.GetById(id);
        return Ok(item);
    }
}
