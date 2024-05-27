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

    }
}
