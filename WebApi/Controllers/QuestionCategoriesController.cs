using Business.Abstracts;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCategoriesController : ControllerBase
    {
        private readonly IQuestionCategoryService _service;

        public QuestionCategoriesController(IQuestionCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(QuestionCategory questionCategory)
        {
            var result = _service.Add(questionCategory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(QuestionCategory questionCategory)
        {
            var result = _service.Add(questionCategory);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(QuestionCategory questionCategory)
        {
            var result = _service.Delete(questionCategory);
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
