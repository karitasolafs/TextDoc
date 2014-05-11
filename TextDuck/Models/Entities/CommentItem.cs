using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class CommentItem
    {
        public int Id { get; set; }

        public String Username { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
//loll