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
    public class QuestionRatingManager : IQuestionRatingService
    {
        public IDataResult<QuestionRating> Add(QuestionRating questionRating)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionRating questionRating)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionRating questionRating)
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionRating> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionRating>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
