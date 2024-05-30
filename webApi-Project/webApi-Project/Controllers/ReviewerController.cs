using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webApi_Project.Dto;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller 
    {
        private readonly IMapper mapper;
        private readonly IReviewerRepository reviewerRepository;

        public ReviewerController(IMapper mapper, IReviewerRepository reviewerRepository)
        {
            this.mapper = mapper;
            this.reviewerRepository = reviewerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewers()
        {
            var reviewers = mapper.Map<List<ReviewerDto>>(reviewerRepository.GetReviewers());
                
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(reviewers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewer(int id)
        {
            if (!reviewerRepository.ReviewerExists(id))
                return NotFound();
            var reviewer = mapper.Map<ReviewerDto>(reviewerRepository.GetReviewer(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewer);
        }

        [HttpGet("/reviews/{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewsByReviewerId(int reviewerId)
        {
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviews = mapper.Map<List<ReviewDto>>(reviewerRepository.GetReviewsByReviewerId(reviewerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }

    }
}
