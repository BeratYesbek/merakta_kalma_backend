using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Entity.Abstract;
using Entity.Concretes.Models;

namespace Entity.Concretes.Dtos
{
    public class QuestionReadDto : IDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Tag[] Tags { get; set; }

        public QuestionRating[] Rating { get; set; }

        public QuestionTag QuestionTag { get; set; }

        public QuestionComment[] QuestionComment { get; set; }

    }
}
