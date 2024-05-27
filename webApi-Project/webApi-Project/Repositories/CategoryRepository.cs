using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public bool CategoryExist(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return context.PokemonCategories.Where(c => c.CategotyId == categoryId).Select(p => p.Pokemon).ToList();
        }
    }
}
