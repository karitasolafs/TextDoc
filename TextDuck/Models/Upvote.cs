using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class Upvote
    {
        public int commentID { get; set; }

        public int upvoteID { get; set; }
    }
}
