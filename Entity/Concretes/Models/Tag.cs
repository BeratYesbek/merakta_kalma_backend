using System.ComponentModel.DataAnnotations.Schema;
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
