using Business.Abstracts;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCommentLikesController : ControllerBase
    {
        private readonly IQuestionCommentLikeService _service;

        public QuestionCommentLikesController(IQuestionCommentLikeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(QuestionCommentLike like)
        {
            var result = _service.Add(like);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(QuestionCommentLike like)
        {
            var result = _service.Add(like);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(QuestionCommentLike like)
        {
            var result = _service.Delete(like);
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
