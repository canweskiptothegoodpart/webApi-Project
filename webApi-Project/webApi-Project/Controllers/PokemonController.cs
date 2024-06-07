using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webApi_Project.Dto;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller

    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IMapper mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this.pokemonRepository = pokemonRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = mapper.Map<List<PokemonDto>>(pokemonRepository.GetPokemons());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int id)
        {
            if (!pokemonRepository.Exists(id))
                return NotFound();
            var pokemon = mapper.Map<PokemonDto>(pokemonRepository.GetPokemon(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByName(string name)
        {
            var pokemon = mapper.Map<PokemonDto>(pokemonRepository.GetPokemon(name));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] PokemonDto pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            var pokemon = pokemonRepository.GetPokemons()
                .Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();
            if (pokemon != null)
            {
                ModelState.AddModelError("", "Pokemon already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var pokemonMap = mapper.Map<Pokemon>(pokemonCreate);

            if (!pokemonRepository.PokemonCreate(ownerId, categoryId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }

    }
}
