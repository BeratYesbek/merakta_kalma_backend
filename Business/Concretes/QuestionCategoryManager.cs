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
    public class QuestionCategoryManager : IQuestionCategoryService
    {
        public IDataResult<QuestionCategory> Add(QuestionCategory questionCategory)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionCategory questionCategory)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionCategory questionCategory)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionCategory> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionCategory>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
