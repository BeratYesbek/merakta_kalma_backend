using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes.Dtos
{
    public class QuestionCreateDto : IDto
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public string[] Tags { get; set; }

        public IFormFile[] Files { get; set; }
    }
}
