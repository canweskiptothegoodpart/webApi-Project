using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext context;
        public ReviewerRepository(DataContext context)
        {
            this.context = context;
        }

        public Reviewer GetReviewer(int id)
        {
            return context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        }


        public ICollection<Reviewer> GetReviewers()
        {
            return context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewerId(int reviewerId)
        {
            return context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return context.Reviewers.Any(r => r.Id == id);
        }
    }
}
