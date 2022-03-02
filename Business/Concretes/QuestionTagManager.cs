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
    public class QuestionTagManager : IQuestionTagService
    {
        private IQuestionTagDal _questionTagDal;

        public QuestionTagManager(IQuestionTagDal questionTagDal)
        {
            _questionTagDal = questionTagDal;
        }

        public IDataResult<QuestionTag> Add(QuestionTag tag)
        {
            var data = _questionTagDal.Add(tag);
            if (data != null)
            {
                return new SuccessDataResult<QuestionTag>(data);
            }

            return new ErrorDataResult<QuestionTag>(null);
        }

        public IResult Update(QuestionTag tag)
        {
            _questionTagDal.Update(tag);
            return new SuccessResult();
        }

        public IResult Delete(QuestionTag tag)
        {
            _questionTagDal.Delete(tag);
            return new SuccessResult();
        }

        public IDataResult<QuestionTag> Get(int id)
        {
            var data = _questionTagDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionTag>(data);
            }

            return new ErrorDataResult<QuestionTag>(null);
        }

        public IDataResult<List<QuestionTag>> GetAll()
        {
            var data = _questionTagDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionTag>>(data);
            }

            return new ErrorDataResult<List<QuestionTag>>(null);
        }
    }
}
