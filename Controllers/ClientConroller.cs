using Microsoft.AspNetCore.Mvc;
using WinterEquipmentRentalApi.Dto.Client;
using WinterEquipmentRentalApi.Services.Abstraction;

namespace WinterEquipmentRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await service.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var client = await service.GetById(id);
            return Ok(client);
        }

        [HttpGet("phone/{phoneNumber}")]
        public async Task<IActionResult> GetByPhone(string phoneNumber)
        {
            var client = await service.GetByPhoneNumber(phoneNumber);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            var id = await service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateClientDto dto)
        {
            await service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await service.Remove(id);
            return NoContent();
        }
    }
}
