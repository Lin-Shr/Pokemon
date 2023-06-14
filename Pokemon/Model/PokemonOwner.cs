namespace Pokemon.Model
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemons Pokemons { get; set; }
        public Owner Owner { get; set; }

    }
}
