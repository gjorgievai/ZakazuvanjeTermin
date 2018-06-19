using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Име")]
        public string FirstName { get; set; }
        [Display(Name = "Презиме")]
        public string LastName { get; set; }
        public virtual List<Pacient> pacients { get; set; }
        public Doctor()
        {
            pacients = new List<Pacient>();
        }

    }
}