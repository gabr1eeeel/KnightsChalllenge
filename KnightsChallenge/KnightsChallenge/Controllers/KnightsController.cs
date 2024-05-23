using KnightsChallenge.Models;
using KnightsChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnightsChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnightsController : ControllerBase
    {
        private readonly KnightService _knightService;

        public KnightsController(KnightService knightService)
        {
            _knightService = knightService;
        }

        [HttpGet]
        public async Task<List<Knight>> GetKnights()
            => await _knightService.GetAsync();

        [HttpGet]
        [Route("heroes")]
        public async Task<List<Knight>> GetHeroes()
            => await _knightService.GetHeroesAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKnightById(string id)
        {
            try
            {
                var knight = await _knightService.GetAsync(id);

                if (knight == null)
                {
                    return NotFound();
                }

                return Ok(knight);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Knight>> PostKnight(Knight knight)
        {
            var existingKnight = await _knightService.GetAsync(knight.Id);
            if (knight.Weapons != null && knight.Weapons.Count(w => w.Equipped) > 1)
            {
                return BadRequest("O cavaleiro só pode ter uma arma equipada de cada vez.");
            }

            if (existingKnight != null && existingKnight.Weapons != null && existingKnight.Weapons.Any(w => w.Equipped))
            {
                return BadRequest("O cavaleiro já tem uma arma equipada. Não é possível adicionar outra.");
            }


            await _knightService.CreateAsync(knight);

            return knight;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateKnight(string id, Knight knight)
        {
            try
            {
                await _knightService.UpdateAsync(id, knight.Nickname);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnight(string id)
        {
            try
            {
                await _knightService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
