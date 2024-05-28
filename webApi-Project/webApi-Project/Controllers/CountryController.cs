using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi_Project.Dto;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController: Controller
    {

        private readonly IMapper mapper;
        private readonly ICountryRepository countryRepository;

        public CountryController(IMapper mapper, ICountryRepository countryRepository)
        {
            this.mapper = mapper;
            this.countryRepository = countryRepository; 
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]

        public IActionResult GetCountries()
        {
            var countries = mapper.Map<List<CountryDto>>(countryRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]

        public IActionResult GetCountry(int id)
        {
            if (!countryRepository.CountryExists(id))
                return NotFound();
            var country = mapper.Map<CountryDto>(countryRepository.GetCountryById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]

        public IActionResult GetCountryByOnwerId(int ownerId)
        {
            var country = mapper.Map<CountryDto>(countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }

    }
}
