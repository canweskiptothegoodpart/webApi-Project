using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
