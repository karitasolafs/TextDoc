using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class UpvoteRepository
    {
        private static UpvoteRepository _instance;

		public static UpvoteRepository Instance
		{
			get
			{
                if (_instance == null)
                    _instance = new UpvoteRepository();
                    return _instance;
			}
		}

		private List<Upvote> upvote = null;

		private UpvoteRepository()		//Fyrirfram tilbúið læk.
		{
			this.upvote = new List<Upvote>();
			Upvote upvote1 = new Upvote { upvoteID = 1, commentID = 1 };
			this.upvote.Add(upvote1);
		}

		public IEnumerable<Upvote> GetUpvote()		//Náum í lækin.
		 {
			var result = from c in upvote
						// orderby c.upvoteDate ascending
						 select c;
			return result;
		}

		public IEnumerable<Upvote> GetUpvote(int ID)		//Náum í læk með CommentID jafnt ID sem við tökum inn.
		{
			var result = from c in upvote
						 where c.commentID == ID
						// orderby c.LikeDate ascending
						 select c;
			return result;
		}

		public void AddUpvote(Upvote c)
		{
				int newID = 1;
				if (upvote.Count() > 0)
				{
					newID = upvote.Max(x => x.upvoteID) + 1;
				}
				c.upvoteID = newID;
				upvote.Add(c);
			}
		}
}
