using Pokemon.Interfaces;
using Pokemon.Model;
using PokemonReview.Data;

namespace Pokemon.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemons> GetPokemons()
        {
           return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public Pokemons GetPokemons(int id)
        {
            //return _context.Pokemons.Where(p => p.Id == id).SingleOrDefault();
            return _context.Pokemons.Find(id);

        }

        public Pokemons GetPokemons(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }
        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
            if (review.Count() <=0 ){
            return 0;
            }
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }


        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(p => p.Id == pokeId);
        }
    }
    
}
