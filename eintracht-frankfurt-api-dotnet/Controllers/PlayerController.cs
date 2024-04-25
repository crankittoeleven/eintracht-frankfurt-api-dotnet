using eintracht_frankfurt_api_dotnet.Models;
using eintracht_frankfurt_api_dotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eintracht_frankfurt_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _unitOfWork.Player.GetAll();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _unitOfWork.Player.GetById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(Player player)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }

            await _unitOfWork.Player.Add(player);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetPlayer", new { player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLanguage(int id, Player player)
        {
            if (await _unitOfWork.Player.GetById(id) == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return new JsonResult("Something wen wrong") { StatusCode = 500 };
            }

            player.Id = id;

            await _unitOfWork.Player.Update(player);
            await _unitOfWork.CompleteAsync();

            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            if (await _unitOfWork.Player.GetById(id) == null)
            {
                return NotFound();
            }

            await _unitOfWork.Player.Delete(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
