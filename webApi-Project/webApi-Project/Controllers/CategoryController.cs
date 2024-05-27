using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi_Project.Dto;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = mapper.Map<List<CategoryDto>>(categoryRepository.GetCategories());
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int id)
        {
            if (!categoryRepository.CategoryExist(id))
                return NotFound();
            var category = mapper.Map<CategoryDto>(categoryRepository.GetCategory(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonsByCategoryId(int categoryId)
        {
            var pokemons = mapper.Map<List<PokemonDto>>(categoryRepository.GetPokemonByCategory(categoryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }

    }
}
