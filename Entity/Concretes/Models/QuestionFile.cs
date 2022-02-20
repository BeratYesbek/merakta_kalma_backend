using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Entity.Concretes.ExternalModel;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes.Models
{
    public class QuestionFile : CloudinaryFile, IEntity
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [NotMapped]
        public IFormFile[] Files { get; set; }
    }
}
