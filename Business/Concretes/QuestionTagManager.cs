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
    public class QuestionTagManager : IQuestionTagService
    {
        public IDataResult<QuestionTag> Add(QuestionTag tag)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionTag tag)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionTag tag)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionTag> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionTag>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
