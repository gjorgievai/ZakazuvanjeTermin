using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class Pacient
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Име")]
        public string FirstName { get; set; }
        [Display(Name = "Презиме")]
        public string LastName { get; set; }
        [Display(Name = "Матичен број")]
        public string  EMBG { get; set; }
        [Display(Name = "Крвна група")]
        public string KrvnaGrupa { get; set; }
        public Doctor Doctor { get; set; }
        public virtual List<Recepta> recepti { get; set; }
        public Pacient()
        {
            Doctor = new Doctor();
            recepti = new List<Recepta>();
        }
    }
}