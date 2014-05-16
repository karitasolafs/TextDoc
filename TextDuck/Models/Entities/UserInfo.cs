using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Entity class for UserInfo
namespace TextDuck.Models.Entities
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public int BirthYear { get; set; }
    }
}