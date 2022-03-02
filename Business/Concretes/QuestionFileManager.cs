using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class QuestionFileManager : IQuestionFileService
    {
        private readonly IQuestionFileDal _questionFileDal;

        public QuestionFileManager(IQuestionFileDal questionFileDal)
        {
            _questionFileDal = questionFileDal;
        }

        public IDataResult<QuestionFile> Add(QuestionFile file)
        {
            var data = _questionFileDal.Add(file);
            if (data != null)
            {
                return new SuccessDataResult<QuestionFile>(data);
            }

            return new ErrorDataResult<QuestionFile>(null);
        }

        public IResult Update(QuestionFile file)
        {
            _questionFileDal.Update(file);
            return new SuccessResult();
        }

        public IResult Delete(QuestionFile file)
        {
            _questionFileDal.Delete(file);
            return new SuccessResult();
        }

        public IDataResult<QuestionFile> Get(int id)
        {
            var data = _questionFileDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionFile>(data);
            }

            return new ErrorDataResult<QuestionFile>(null);
        }

        public IDataResult<List<QuestionFile>> GetByQuestionId(int id)
        {
            var data = _questionFileDal.GetAll(q => q.QuestionId == id);
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionFile>>(data);
            }
            return new ErrorDataResult<List<QuestionFile>>(null);
        }

        public IDataResult<List<QuestionFile>> GetAll()
        {
            var data = _questionFileDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionFile>>(data);
            }

            return new ErrorDataResult<List<QuestionFile>>(null);
        }
    }
}
