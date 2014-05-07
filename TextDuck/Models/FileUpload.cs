using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class FileUpload
    {
        public int? FileId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string FileTitle { get; set; }

        [Required(ErrorMessage = "A file is required.")]
        public string FileContent { get; set; }

        public DateTime FileDate { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string FileCategory { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string FileGenre { get; set; }
    }
}