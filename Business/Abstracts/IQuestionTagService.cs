using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionTagService
    {
        IDataResult<QuestionTag> Add(QuestionTag tag);

        IResult Update(QuestionTag tag);

        IResult Delete(QuestionTag tag);

        IDataResult<QuestionTag> Get(int id);

        IDataResult<List<QuestionTag>> GetAll();
    }
}
