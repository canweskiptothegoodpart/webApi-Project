using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        bool Exists(int id);
    }
}
