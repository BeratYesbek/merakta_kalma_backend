using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionCommentDislikeService
    {
        IDataResult<QuestionCommentDislike> Add(QuestionCommentDislike dislike);

        IResult Update(QuestionCommentDislike dislike);

        IResult Delete(QuestionCommentDislike dislike);

        IDataResult<QuestionCommentDislike> Get(int id);


        IDataResult<List<QuestionCommentDislike>> GetAll();
    }
}
