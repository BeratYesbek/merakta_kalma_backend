using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Entity;
using Entity.Concretes.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public static string DbConnectionString { get; set; } =
            "Server=(localdb)\\MSSQLLocalDB;Database=AppDbContext;Trusted_Connection=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnectionString);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims   { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionComment> QuestionComments { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionCommentDislike> QuestionCommentDislikes { get; set; }
        public DbSet<QuestionCommentLike> QuestionCommentLikes { get; set; }
        public DbSet<QuestionRating> QuestionRatings { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        
        public DbSet<QuestionFile> QuestionFiles { get; set; }
        public DbSet<Tag> Tags { get; set; }


       

    }
}
