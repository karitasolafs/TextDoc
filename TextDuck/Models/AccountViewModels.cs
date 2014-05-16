using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.UF;

namespace TextDuck.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Notandanafn")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Núverandi lykilorð")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera að minnsta kosti {2} stafir", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nýtt lykilorð")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta")]
        [Compare("NewPassword", ErrorMessage = "Ekki var samræmi á milli lykilorða")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Notandanafn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [Display(Name = "Vista upplýsingar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Slá verður inn nafn")]
        [Display(Name = "Nafn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Slá verður inn netfang / Ekki rétt slegið inn")]
        [Display(Name = "Netfang")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Kyn")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Veldu fæðingarár")]
        [Display(Name = "Fæðingarár")]
        public int BirthYear { get; set; }


        [Required]
        [Display(Name = "Notandanafn")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} verður að vera að minnsta kost {2} tákn að lengd.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta lykilorð")]
        [Compare("Password", ErrorMessage = "Ekki var samræmi á milli lykilorða")]
        public string ConfirmPassword { get; set; }
    }
}
