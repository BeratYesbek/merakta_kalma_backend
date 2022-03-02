using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IQuestionService _service;

        public QuestionsController(IMapper mapper, IQuestionService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] QuestionCreateDto questionCreateDto)
        {
            var question = _mapper.Map<Question>(questionCreateDto);
            var file = _mapper.Map<QuestionFile>(questionCreateDto);
            var tag = _mapper.Map<Tag>(questionCreateDto);

            var result = await _service.Add(question, file, tag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] QuestionCreateDto questionCreateDto)
        {
            var question = _mapper.Map<Question>(questionCreateDto);
            var file = _mapper.Map<QuestionFile>(questionCreateDto);
            var tag = _mapper.Map<Tag>(questionCreateDto);

            var result = _service.Update(question, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAllQuestionsDetail")]
        public IActionResult GetAllQuestionsDetail()
        {
            var result = _service.GetAllQuestionDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getQuestionDetailByQuestionId/{questionId}")]
        public IActionResult GetQuestionDetailByQuestionId(int questionId)
        {
            var result = _service.GetQuestionDetailByQuestionId(questionId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
