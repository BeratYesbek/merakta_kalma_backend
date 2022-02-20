using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionCommentService 
    {
        IDataResult<QuestionComment> Add(QuestionComment questionComment);

        IResult Update(QuestionComment questionComment);

        IResult Delete(QuestionComment questionComment);

        IDataResult<QuestionComment> Get(int id);


        IDataResult<List<QuestionComment>> GetAll();
    }
}
