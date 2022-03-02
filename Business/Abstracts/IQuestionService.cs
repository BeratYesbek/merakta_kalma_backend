using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionService
    {
        Task<IDataResult<Question>> Add(Question question, QuestionFile questionFile, Tag tag);

        IResult Update(Question question, QuestionFile questionFile);

        IResult Delete(Question question);

        IDataResult<Question> Get(int id);

        IDataResult<List<Question>> GetAll();

        IDataResult<List<QuestionReadDto>> GetAllQuestionDetail();

        IDataResult<QuestionReadDto> GetQuestionDetailByQuestionId(int questionId);
    }
}
