using Business.Abstracts;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionRatingsController : ControllerBase
    {
        private readonly IQuestionRatingService _service;

        public QuestionRatingsController(IQuestionRatingService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(QuestionRating rating)
        {
            var result = _service.Add(rating);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(QuestionRating rating)
        {
            var result = _service.Add(rating);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(QuestionRating rating)
        {
            var result = _service.Delete(rating);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
