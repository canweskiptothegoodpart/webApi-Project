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

        public bool Exists(int id)
        {
            return context.Pokemons.Any(p => p.Id == id);
        }

        public Pokemon GetPokemon(int id)
        {
            return context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonCreate(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var pokemonCategoryEntity = context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var pokemonOnwer = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,

            };

            context.Add(pokemonOnwer);

            var pokemonCategory = new PokemonCategory()
            {
                Category = pokemonCategoryEntity,
                Pokemon = pokemon,
            };

            context.Add(pokemonCategory);
            context.Add(pokemon);
            return Save();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
