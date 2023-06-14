namespace Pokemon.Model
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }
        public  Pokemons Pokemons { get; set; }
        public Category Category{ get; set; }

    }
}
