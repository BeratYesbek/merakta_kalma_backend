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
    public class QuestionCommentManager : IQuestionCommentService
    {
        public IDataResult<QuestionComment> Add(QuestionComment questionComment)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionComment questionComment)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionComment questionComment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionComment> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionComment>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
