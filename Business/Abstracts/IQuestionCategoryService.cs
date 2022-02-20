using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionCategoryService
    {
        IDataResult<QuestionCategory> Add(QuestionCategory questionCategory);

        IResult Update(QuestionCategory questionCategory);

        IResult Delete(QuestionCategory questionCategory);

        IDataResult<QuestionCategory> Get(int id);

        IDataResult<List<QuestionCategory>> GetAll();
    }
}
