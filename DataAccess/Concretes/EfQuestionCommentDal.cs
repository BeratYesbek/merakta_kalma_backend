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
    public class EfQuestionCommentDal : EntityRepositoryBase<QuestionComment, AppDbContext>, IQuestionCommentDal
    {
        public List<QuestionCommentReadDto> GetQuestionDetailsByQuestionId(Expression<Func<QuestionComment, bool>> filter)
        {
            using (var context = new AppDbContext())
            {
                var result = from comment in context.QuestionComments.Where(filter)
                    join user in context.Users on comment.UserId equals user.Id
                    select new QuestionCommentReadDto
                    {
                        User = user,
                        Comment = comment,
                        DislikeCount = (from dislike in context.QuestionCommentDislikes where dislike.CommentId == comment.Id select dislike).Count(),
                        LikeCount = (from like in context.QuestionCommentLikes where like.CommentId == comment.Id select like).Count()
                    };
                return result.ToList();
            }
        }
    }
}
