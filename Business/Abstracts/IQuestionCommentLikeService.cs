using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionCommentLikeService 
    {
        IDataResult<QuestionCommentLike> Add(QuestionCommentLike like);

        IResult Update(QuestionCommentLike like);

        IResult Delete(QuestionCommentLike like);

        IDataResult<QuestionCommentLike> Get(int id);


        IDataResult<List<QuestionCommentLike>> GetAll();
    }
}
