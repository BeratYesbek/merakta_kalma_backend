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
    public class QuestionRatingManager : IQuestionRatingService
    {
        private readonly IQuestionRatingDal _questionRatingDal;

        public QuestionRatingManager(IQuestionRatingDal questionRatingDal)
        {
            _questionRatingDal = questionRatingDal;
        }

        public IDataResult<QuestionRating> Add(QuestionRating questionRating)
        {
            var data = _questionRatingDal.Add(questionRating);
            if (data != null)
            {
                return new SuccessDataResult<QuestionRating>(data);
            }
            return new ErrorDataResult<QuestionRating>(null);
        }

        public IResult Update(QuestionRating questionRating)
        {
            _questionRatingDal.Update(questionRating);
            return new SuccessResult();
        }

        public IResult Delete(QuestionRating questionRating)
        {
            _questionRatingDal.Delete(questionRating);
            return new SuccessResult();
        }

        public IDataResult<QuestionRating> Get(int id)
        {
            var data = _questionRatingDal.Get(t => t.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionRating>(data);
            }

            return new ErrorDataResult<QuestionRating>(null);
        }

        public IDataResult<List<QuestionRating>> GetAll()
        {
            var data = _questionRatingDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionRating>>(data);
            }

            return new ErrorDataResult<List<QuestionRating>>(null);
        }
    }
}
