using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionFileService
    {
        IDataResult<QuestionFile> Add(QuestionFile file);

        IResult Update(QuestionFile file);

        IResult Delete(QuestionFile file);

        IDataResult<QuestionFile> Get(int id);

        IDataResult<List<QuestionFile>> GetByQuestionId(int id);


        IDataResult<List<QuestionFile>> GetAll();
    }
}
