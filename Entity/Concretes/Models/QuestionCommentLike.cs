using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entity.Concretes.Models
{
    public class QuestionCommentLike : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CommentId { get; set; }

        public bool Status { get; set; }
    }
}
