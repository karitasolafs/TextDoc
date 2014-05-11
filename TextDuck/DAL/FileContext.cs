using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TextDuck.Models;

namespace TextDuck.DAL
{
    public class FileContext : DbContext
    {
     

            public FileContext(): base("FileContext")
            {
            }

            public DbSet<srtFiles> srtFiles { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }