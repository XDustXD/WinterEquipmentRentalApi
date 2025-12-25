using Microsoft.AspNetCore.Mvc;
using WinterEquipmentRentalApi.Dto.RentalItem;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalItemController(IRentalItemService rentalItemService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRentalItems()
        {
            var rentalItems = await rentalItemService.GetAll();

            return Ok(rentalItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalItemById(string id)
        {
            var rentalItem = await rentalItemService.GetById(id);

            return Ok(rentalItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentalItem(CreateRentalItem rentalItem)
        {
            var id = await rentalItemService.Add(rentalItem);

            return Ok(new { id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentalItem(string id, UpdateRentalItemDto rentalItem)
        {
            await rentalItemService.Update(id, rentalItem);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRentalItem(string id)
        {
            await rentalItemService.Remove(id);
            return NoContent();
        }

    }
}
