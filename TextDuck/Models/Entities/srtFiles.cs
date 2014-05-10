using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class srtFiles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Genre { get; set; }
        public string Language { get; set;}
    }
}