using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models.Entities
{
    public class File
    {
        public int FileId { get; set; }
        public string FileTitle { get; set; }
        public string FileContent { get; set; }

        public DateTime FileDate { get; set; }
        public string FileCategory { get; set; }
        public string FileGenre { get; set; }
        public string FileStatus { get; set; }
    }
}