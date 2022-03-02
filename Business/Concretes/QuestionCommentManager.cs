using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class QuestionCommentManager : IQuestionCommentService
    {
        private readonly IQuestionCommentDal _questionCommentDal;

        public QuestionCommentManager(IQuestionCommentDal questionCommentDal)
        {
            _questionCommentDal = questionCommentDal;
        }

        public IDataResult<QuestionComment> Add(QuestionComment questionComment)
        {
            var data = _questionCommentDal.Add(questionComment);
            if (data != null)
            {
                return new SuccessDataResult<QuestionComment>(data);
            }

            return new ErrorDataResult<QuestionComment>(null);
        }

        public IResult Update(QuestionComment questionComment)
        {
            _questionCommentDal.Update(questionComment);
            return new SuccessResult();
        }

        public IResult Delete(QuestionComment questionComment)
        {
            _questionCommentDal.Delete(questionComment);
            return new SuccessResult();
        }

        public IDataResult<QuestionComment> Get(int id)
        {
            var data = _questionCommentDal.Get(q => q.Id == id);
            if (data != null)
            {
                return new SuccessDataResult<QuestionComment>(data);
            }

            return new ErrorDataResult<QuestionComment>(null);
        }

        public IDataResult<List<QuestionComment>> GetAll()
        {
            var data = _questionCommentDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionComment>>(data);
            }

            return new ErrorDataResult<List<QuestionComment>>(null);
        }

        public IDataResult<List<QuestionCommentReadDto>> GetQuestionDetailsByQuestionId(int questionId)
        {
            var data = _questionCommentDal.GetQuestionDetailsByQuestionId(c => c.QuestionId == questionId);
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<QuestionCommentReadDto>>(data);
            }

            return new ErrorDataResult<List<QuestionCommentReadDto>>(null);
        }
    }
}
