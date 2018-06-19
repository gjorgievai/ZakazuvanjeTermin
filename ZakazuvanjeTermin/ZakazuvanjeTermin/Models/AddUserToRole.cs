using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class AddUserToRole
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> roles { get; set; }
        public AddUserToRole()
        {
            roles = new List<string>();
        }

    }
}