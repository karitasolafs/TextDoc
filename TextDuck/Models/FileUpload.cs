﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.UF;

namespace TextDuck.Models
{
    public class FileUpload
    {
        public int? FileId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Nafn: ")]
        public string FileTitle { get; set; }

        [ValidateFileAttribute(ErrorMessage = "Please select a .srt file")]
        [Display(Name = "Velja skra: ")]
        public HttpPostedFileBase File { get; set; }

        public DateTime FileDate { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Flokkur: ")]
        public string FileCategory { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [Display(Name = "Tegund: ")]
        public string FileGenre { get; set; }
    }
}