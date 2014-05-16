using System;
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

        [Required(ErrorMessage = "Titil vantar")]
        [Display(Name = "Nafn ")]
        public string FileTitle { get; set; }

        [ValidateFileAttribute(ErrorMessage = "Vinsamlegast settu inn .srt skrá")]
        [Display(Name = "Velja skrá ")]
        public HttpPostedFileBase File { get; set; }

        public DateTime FileDate { get; set; }

        [Required(ErrorMessage = "Vinsamlegast veldu flokk")]
        [Display(Name = "Flokkur ")]
        public string FileCategory { get; set; }

        [Required(ErrorMessage = "Vinsamlegast veldu tegund")]
        [Display(Name = "Tegund ")]
        public string FileGenre { get; set; }

        [Required(ErrorMessage = "Vinsamlegast veldu ástand")]
        [Display(Name = "Ástand")]
        public string FileStatus { get; set; }

        [Required(ErrorMessage = "Vinsamlegast veldu tungumál")]
        [Display(Name = "Tungumál")]
        public string FileLanguage { get; set; }

       
    }
}