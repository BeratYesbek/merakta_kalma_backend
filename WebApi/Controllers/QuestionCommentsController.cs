using Business.Abstracts;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCommentsController : ControllerBase
    {
        private readonly IQuestionCommentService _service;

        public QuestionCommentsController(IQuestionCommentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(QuestionComment comment)
        {
            var result = _service.Add(comment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(QuestionComment comment)
        {
            var result = _service.Add(comment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(QuestionComment comment)
        {
            var result = _service.Delete(comment);
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
