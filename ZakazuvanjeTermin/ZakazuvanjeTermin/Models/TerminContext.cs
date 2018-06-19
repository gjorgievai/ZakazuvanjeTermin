using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZakazuvanjeTermin.Models
{
    public class TerminContext: DbContext
    {

        public DbSet<Doctor> doctors { get; set; }
        public TerminContext() : base("DefaultConnection")
        {
        }
        public static TerminContext Create()
        {
            return new TerminContext();
        }
    }
}