using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class UpvoteRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Upvote> GetAllUpvotes()
        {
            return db.Upvote.AsQueryable();
        }


        public IQueryable<Upvote> GetUpvotes()
        {
            var upvotes = (from u in db.Upvote
                           orderby u.srtId
                           where u.srtId != null
                           select u);
            return upvotes;

        }

        public Upvote GetUpvotesId(int id)
        {
            var result = (from u in db.Upvote
                          where u.upvoteID == id
                          select u).SingleOrDefault();
            return result;
        }

        /*public void AddUpvote(Upvote u)
        {
                int newID = 1;
                if (u.Count() > 0)
                {
                    newID = upvote.Max(x => x.upvoteID) + 1;
                }
                c.upvoteID = newID;
                upvote.Add(c);
            }
        }*/
    }
}
