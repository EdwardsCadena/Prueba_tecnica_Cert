using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PokemonApi.Services;

namespace PokemonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;
        private readonly IStringLocalizer<PokemonController> _localizer;

        public PokemonController(PokemonService pokemonService, IStringLocalizer<PokemonController> localizer)
        {
            _pokemonService = pokemonService;
            _localizer = localizer;
        }

        [HttpGet("{nameOrId}")]
        public async Task<IActionResult> GetPokemon(string nameOrId)
        {
            var pokemon = await _pokemonService.GetPokemonAsync(nameOrId);
            if (pokemon == null)
            {
                return NotFound(_localizer["Pokemon not found"]);
            }
            return Ok(pokemon);
        }
    }
}
