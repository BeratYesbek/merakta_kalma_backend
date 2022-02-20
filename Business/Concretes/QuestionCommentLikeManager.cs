using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class QuestionCommentLikeManager : IQuestionCommentLikeService
    {
        public IDataResult<QuestionCommentLike> Add(QuestionCommentLike like)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionCommentLike like)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionCommentLike like)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionCommentLike> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionCommentLike>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
