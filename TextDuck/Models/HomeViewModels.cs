using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class SubtitlesViewModel
    {
        [Required]
        [Display(Name = "Flokkur")]
        public string Category { get; set; }

        [Display(Name = "Tegund")]
        public bool Type { get; set; }

    }
}