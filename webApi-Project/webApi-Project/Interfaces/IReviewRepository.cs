using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewByPokemonId(int pokemonId);
        bool ReviewExists(int id);
    }
}
