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
    public interface IQuestionDal : IEntityRepository<Question>
    {
        List<QuestionReadDto> GetAllQuestionDetail(Expression<Func<QuestionReadDto,bool>> filter = null);

        QuestionReadDto GetQuestionDetail(Expression<Func<Question, bool>> filter);
    }
}
