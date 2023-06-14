using Microsoft.AspNetCore.Mvc;
using Pokemon.Interfaces;
using Pokemon.Model;

namespace Pokemon.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller])")]
    [ApiController]

    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);

        }
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId) {

            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound("Pokemon Not Found");
            }
            var pokemon = _pokemonRepository.GetPokemons(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
        [HttpGet("Name")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(string name)
        {
            if (!_pokemonRepository.PokemonExists(name)) { 
                return NotFound("No Pokemon of that name exists");
        }
            var pokemon = _pokemonRepository.GetPokemons(name);
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

    }
}
