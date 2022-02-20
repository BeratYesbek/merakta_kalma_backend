using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entity.Concretes.Models
{
    public class QuestionTag : IEntity
    {
        public int Id { get; set; }

        public int TagId { get; set; }

        public int QuestionId { get; set; }
    }
}
