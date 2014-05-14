using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class CommentItem
    {
        public int Id               { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title         { get; set; }
        [Required(ErrorMessage = "Text is required.")]
        public string Text          { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName      { get; set; }
        public int srtId            { get; set; }
        public string srtTitle      { get; set; }

           public CommentItem()
        {
            DateCreated = DateTime.Now; // fáum tíma og dagsetningu automatically
        }
    }
}
//loll