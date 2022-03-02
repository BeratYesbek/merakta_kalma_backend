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
    public class QuestionCategoryManager : IQuestionCategoryService
    {
        private readonly IQuestionCategoryDal _questionCategoryDal;


        public QuestionCategoryManager(IQuestionCategoryDal questionCategoryDal)
        {
            _questionCategoryDal = questionCategoryDal;
        }

        public IDataResult<QuestionCategory> Add(QuestionCategory questionCategory)
        {
            var data = _questionCategoryDal.Add(questionCategory);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCategory>(data);
            }
            return new ErrorDataResult<QuestionCategory>(null);
        }

        public IResult Update(QuestionCategory questionCategory)
        {
            _questionCategoryDal.Update(questionCategory);
            return new SuccessResult();
        }

        public IResult Delete(QuestionCategory questionCategory)
        {
            _questionCategoryDal.Delete(questionCategory);
            return new SuccessResult();
        }

        public IDataResult<QuestionCategory> Get(int id)
        {
            var data = _questionCategoryDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCategory>(data);
            }

            return new ErrorDataResult<QuestionCategory>(null);
        }

        public IDataResult<List<QuestionCategory>> GetAll()
        {
            var data = _questionCategoryDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionCategory>>(data);
            }

            return new ErrorDataResult<List<QuestionCategory>>(null);
        }
    }
}
