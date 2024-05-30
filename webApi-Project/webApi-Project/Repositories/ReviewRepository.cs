using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext context;

        public ReviewRepository(DataContext context)
        {
            this.context = context;
        }

        public Review GetReview(int id)
        {
            return context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewByPokemonId(int pokemonId)
        {
            return context.Reviews.Where(r => r.Pokemon.Id == pokemonId).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public bool ReviewExists(int id)
        {
            return context.Reviews.Any(r => r.Id == id);    
        }
    }
}
