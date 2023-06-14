using Pokemon.Model;

namespace Pokemon.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemons> GetPokemons();

        Pokemons GetPokemons(int id);
        Pokemons GetPokemons(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool PokemonExists(string name);
    }
}
