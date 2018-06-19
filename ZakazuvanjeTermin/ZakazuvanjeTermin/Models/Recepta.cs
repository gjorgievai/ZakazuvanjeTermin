using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class Recepta
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Милиграми")]
        public int miligrami { get; set; }
        [Display(Name = "Дневна доза")]
        public int dozvolenaDoza { get; set; }
    }
}