using Microsoft.AspNetCore.Mvc;
using WinterEquipmentRentalApi.Repostitory.Abstraction;

namespace WinterEquipmentRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientRepostitory repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await repository.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailable(string id)
        {
            var client = await repository.GetById(id);
            return Ok(client);
        }
    }
}
