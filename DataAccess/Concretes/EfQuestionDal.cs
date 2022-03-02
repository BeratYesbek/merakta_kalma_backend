using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using DataAccess.Abstracts;
using Entity.Concretes.Dtos;
using Entity.Concretes.Models;

namespace DataAccess.Concretes
{
    public class EfQuestionDal : EntityRepositoryBase<Question, AppDbContext>, IQuestionDal
    {
        public List<QuestionReadDto> GetAllQuestionDetail(Expression<Func<QuestionReadDto, bool>> filter = null)
        {
            using (var context = new AppDbContext())
            {
                var result = from question in context.Questions.DefaultIfEmpty()
                             join questionTag in context.QuestionTags on question.Id equals questionTag.QuestionId
                             select new QuestionReadDto
                             {
                                 Id = question.Id,
                                 Title = question.Title,
                                 Description = question.Description,
                                 UserId = question.UserId,
                                 QuestionTag = questionTag,
                                 Tags = (from tag in context.Tags where tag.Id == questionTag.TagId select tag).ToArray(),
                                 QuestionComment = (from comment in context.QuestionComments where comment.QuestionId == question.Id select comment).ToArray(),
                                 Rating = (from rating in context.QuestionRatings where rating.QuestionId == question.Id select rating).ToArray(),
                             };
                return filter is not null ? result.Where(filter).ToList() : result.ToList();
            }
        }

        public QuestionReadDto GetQuestionDetail(Expression<Func<Question, bool>> filter)
        {
            using (var context = new AppDbContext())
            {
                var result = from question in context.Questions.Where(filter)
                             join questionTag in context.QuestionTags on question.Id equals questionTag.QuestionId
                             join user in context.Users on question.UserId equals user.Id
                             select new QuestionReadDto
                             {
                                 Id = question.Id,
                                 Title = question.Title,
                                 UserId = question.UserId,
                                 Description = question.Description,
                                 User = user,
                                 QuestionTag = questionTag,
                                 Tags = (from tag in context.Tags where tag.Id == questionTag.TagId select tag).ToArray(),
                                 QuestionComment = (from comment in context.QuestionComments where comment.QuestionId == question.Id select comment).ToArray(),
                                 Rating = (from rating in context.QuestionRatings where rating.QuestionId == question.Id select rating).ToArray(),
                             };
                return result.FirstOrDefault();
            }
        }
    }
}