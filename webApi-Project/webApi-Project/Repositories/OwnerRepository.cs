using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext context;

        public OwnerRepository(DataContext context)
        {
            this.context = context;
        }

        public Owner GetOwner(int id)
        {
           return context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerByPokemonId(int pokemonId)
        {
            return context.PokemonOwners.Where(po => po.PokemonId == pokemonId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return context.Owners.OrderBy(o => o.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwnerId(int ownerId)
        {
            return context.PokemonOwners.Where(po => po.OwnerId == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
