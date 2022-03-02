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
    public class QuestionCommentLikeManager : IQuestionCommentLikeService
    {
        private readonly IQuestionCommentLikeDal _questionCommentLikeDal;

        public QuestionCommentLikeManager(IQuestionCommentLikeDal questionCommentLikeDal)
        {
            _questionCommentLikeDal = questionCommentLikeDal;
        }

        public IDataResult<QuestionCommentLike> Add(QuestionCommentLike like)
        {
            var data = _questionCommentLikeDal.Add(like);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCommentLike>(like);
            }

            return new ErrorDataResult<QuestionCommentLike>(null);
        }

        public IResult Update(QuestionCommentLike like)
        {
            _questionCommentLikeDal.Update(like);
            return new SuccessResult();
        }

        public IResult Delete(QuestionCommentLike like)
        {
            _questionCommentLikeDal.Delete(like);
            return new SuccessResult();
        }

        public IDataResult<QuestionCommentLike> Get(int id)
        {
            var data = _questionCommentLikeDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCommentLike>(data);
            }

            return new ErrorDataResult<QuestionCommentLike>(null);
        }

        public IDataResult<List<QuestionCommentLike>> GetAll()
        {
            var data = _questionCommentLikeDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionCommentLike>>(data);
            }

            return new ErrorDataResult<List<QuestionCommentLike>>(null);
        }
    }
}
