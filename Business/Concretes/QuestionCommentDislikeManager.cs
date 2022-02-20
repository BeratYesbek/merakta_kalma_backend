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
    public class QuestionCommentDislikeManager : IQuestionCommentDislikeService
    {
        public IDataResult<QuestionCommentDislike> Add(QuestionCommentDislike dislike)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionCommentDislike dislike)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionCommentDislike dislike)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionCommentDislike> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionCommentDislike>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
