using System.Collections.Generic;
using Core.Utilities.Result;
using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IQuestionRatingService
    {
        IDataResult<QuestionRating> Add(QuestionRating questionRating);

        IResult Update(QuestionRating questionRating);

        IResult Delete(QuestionRating questionRating);

        IDataResult<QuestionRating> Get(int id);

        IDataResult<List<QuestionRating>> GetAll();
    }
}
