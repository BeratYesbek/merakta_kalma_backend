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
    public class QuestionCommentDislikeManager : IQuestionCommentDislikeService
    {
        private readonly IQuestionCommentDislikeDal _questionCommentDislikeDal;

        public QuestionCommentDislikeManager(IQuestionCommentDislikeDal questionCommentDislikeDal)
        {
            _questionCommentDislikeDal = questionCommentDislikeDal;
        }

        public IDataResult<QuestionCommentDislike> Add(QuestionCommentDislike dislike)
        {
            var data = _questionCommentDislikeDal.Add(dislike);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCommentDislike>(data);
            }

            return new ErrorDataResult<QuestionCommentDislike>(null);
        }

        public IResult Update(QuestionCommentDislike dislike)
        {
            _questionCommentDislikeDal.Update(dislike);
            return new SuccessResult();
        }

        public IResult Delete(QuestionCommentDislike dislike)
        {
            _questionCommentDislikeDal.Delete(dislike);
            return new SuccessResult();
        }

        public IDataResult<QuestionCommentDislike> Get(int id)
        {
            var data = _questionCommentDislikeDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionCommentDislike>(data);
            }

            return new ErrorDataResult<QuestionCommentDislike>(null);
        }

        public IDataResult<List<QuestionCommentDislike>> GetAll()
        {
            var data = _questionCommentDislikeDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionCommentDislike>>(data);
            }

            return new ErrorDataResult<List<QuestionCommentDislike>>(null);
        }
    }
}
