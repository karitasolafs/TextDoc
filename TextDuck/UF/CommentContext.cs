using System;
using TextDuck.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TextDuck.UF
{
    public class CommentContext : DbContext
    {
        public CommentContext()
            : base("CommentContext")
        {
            
        }

        public DbSet<CommentItem> Comment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}