using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace DataAccess.Abstracts
{
    public interface IQuestionCommentDal : IEntityRepository<QuestionComment>
    {
        List<QuestionCommentReadDto> GetQuestionDetailsByQuestionId(Expression<Func<QuestionComment, bool>> filter);
    }
}
