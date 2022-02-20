using Business.Abstracts;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCommentDislikesController : ControllerBase
    {
        private readonly IQuestionCommentDislikeService _service;
        public QuestionCommentDislikesController(IQuestionCommentDislikeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(QuestionCommentDislike dislike)
        {
            var result = _service.Add(dislike);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(QuestionCommentDislike dislike)
        {
            var result = _service.Add(dislike);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(QuestionCommentDislike dislike)
        {
            var result = _service.Delete(dislike);
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
