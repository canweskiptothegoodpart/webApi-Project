using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}
