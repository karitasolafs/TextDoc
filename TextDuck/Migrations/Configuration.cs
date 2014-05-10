namespace TextDuck.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TextDuck.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TextDuck.Models.ApplicationDbContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TextDuck.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var Comment = new List<CommentItem>
            //{
            //    new CommentItem{
            //        Title = "Komment",
            //        Text = "Nei en kul, er haegt ad kommenta her",
            //        DateCreated = DateTime.Parse("2014-02-27 23:36:00")
            //    },
              
            //};
            //Comment.ForEach(s => context.Comment.Add(s));
            //context.SaveChanges();
        }
    }
}
