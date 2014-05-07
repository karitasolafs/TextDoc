using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TextDuck.Models;

namespace TextDuck.UF
{
    public class UploadContext : DbContext
    {
        public UploadContext()
            : base("UploadContext")
        {

        }

        public DbSet<FileUpload> File { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}