using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Entity.Concretes.Models;

namespace Entity.Concretes.Dtos
{
    public class QuestionCommentReadDto
    {
        public QuestionComment Comment { get; set; }

        public User User { get; set; }

        public int DislikeCount { get; set; }

        public int LikeCount { get; set; }
    }
}
