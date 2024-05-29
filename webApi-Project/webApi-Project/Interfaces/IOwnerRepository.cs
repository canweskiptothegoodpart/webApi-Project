using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int id);
        ICollection<Pokemon> GetPokemonsByOwnerId(int ownerId);
        ICollection<Owner> GetOwnerByPokemonId(int pokemonId);
        bool OwnerExists(int ownerId);

    }
}
