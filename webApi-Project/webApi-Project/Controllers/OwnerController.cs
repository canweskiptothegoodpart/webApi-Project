using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi_Project.Dto;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOwnerRepository ownerRepository;
        private readonly ICountryRepository countryRepository;

        public OwnerController(IMapper mapper, IOwnerRepository ownerRepository, ICountryRepository countryRepository)
        {
            this.mapper = mapper;
            this.ownerRepository = ownerRepository;
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]

        public IActionResult GetOwners()
        {
            var owners = mapper.Map<List<OwnerDto>>(ownerRepository.GetOwners());
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(owners);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int id)
        {
            if (!ownerRepository.OwnerExists(id))
                return NotFound();
            var owner = mapper.Map<OwnerDto>(ownerRepository.GetOwner(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);

        }


        [HttpGet("/owner/{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]

        public IActionResult GetOwnersByPokemonId(int pokemonId)
        {
            var owners = mapper.Map<List<OwnerDto>>(ownerRepository.GetOwnerByPokemonId(pokemonId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }


        [HttpGet("/pokemon/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonsByOwnerId(int ownerId)
        {
            var pokemons = mapper.Map<List<PokemonDto>>(ownerRepository.GetPokemonsByOwnerId(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
           


        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateOwner([FromQuery] int countryId , [FromBody] OwnerDto ownerCreate)
        { 
            if (ownerCreate == null)
                return BadRequest(ModelState);

            var owner = ownerRepository.GetOwners()
                .Where(c => c.Name.Trim().ToUpper() == ownerCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();
            if (owner != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }
             
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);


            var ownerMap = mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = countryRepository.GetCountryById(countryId);
            if (!ownerRepository.OwnerCreate(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }




    }
}
