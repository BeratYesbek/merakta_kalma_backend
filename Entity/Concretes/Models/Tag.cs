using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Entity.Concretes.Models
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public string[] Tags { get; set; }
    }
}
