using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.Models;

namespace TextDuck.UF
{
    public class CommentInitializer : System.Data.Entity.CreateDatabaseIfNotExists<CommentContext>
    {
         protected override void Seed(CommentContext context)
        {
            var Comment = new List<CommentItem>
            {
                new CommentItem{
                    Title = "Komment",
                    Text = "Nei en kul, er haegt ad kommenta her",
                    DateCreated = DateTime.Parse("2014-02-27 23:36:00")
                },
              
            };
            Comment.ForEach(s => context.Comment.Add(s));
            context.SaveChanges();
        }

 
    }
}
       