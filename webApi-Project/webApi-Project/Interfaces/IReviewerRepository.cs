using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewerId(int reviewerId);
        bool ReviewerExists(int id);
    }
}
