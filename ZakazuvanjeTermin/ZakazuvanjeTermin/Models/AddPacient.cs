using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class AddPacient
    {
        public int pacientId { get; set; }
        public int doctorId { get; set; }
        public List<Pacient> pacients { get; set; }
        public AddPacient()
        {
            pacients = new List<Pacient>();
        }
    }
}