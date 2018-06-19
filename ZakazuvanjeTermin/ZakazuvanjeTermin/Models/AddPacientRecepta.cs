using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class AddPacientRecepta
    {
        public int selectedPacient { get; set; }
        public int selectedRecepta { get; set; }
        public List<Recepta> recepti { get; set; }
        public AddPacientRecepta()
        {
            recepti = new List<Recepta>();
        }


    }
}