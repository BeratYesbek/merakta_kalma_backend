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
    public class QuestionFileManager : IQuestionFileService
    {
        public IDataResult<QuestionFile> Add(QuestionFile file)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionFile file)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionFile file)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionFile> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionFile>> GetByQuestionId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionFile>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
