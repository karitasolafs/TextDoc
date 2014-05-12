using System;
using TextDuck.UF;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class CommentRepository
    {
        private static CommentRepository instance;

        public static CommentRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommentRepository();
                return instance;
            }
        }

        private List<CommentItem> comments = null;

        private CommentRepository()
        {
            this.comments = new List<CommentItem>();
            CommentItem commment1 = new CommentItem { Id = 1, Text = "Great Video!", DateCreated = new DateTime(2014, 3, 1, 12, 30, 00), Title = "Patrekur" };
            CommentItem commment2 = new CommentItem { Id = 2, Text = "Amazing content!", DateCreated = new DateTime(2014, 3, 5, 12, 30, 00), Title = "Siggi" };
            this.comments.Add(commment1);
            this.comments.Add(commment2);
        }

        public IEnumerable<CommentItem> GetComments()
        {
            var result = from c in comments
                            orderby c.DateCreated ascending
                            select c;
            return result;
        }

        public void AddComment(CommentItem c)
        {
            int newID = 1;
            if (comments.Count() > 0)
            {
                newID = comments.Max(x => x.Id) + 1;
            }
            c.Id = newID;
            c.DateCreated = DateTime.Now;
            comments.Add(c);
        }
    }
    
}