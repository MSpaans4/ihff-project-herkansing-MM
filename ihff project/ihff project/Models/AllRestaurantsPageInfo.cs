using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff_project.Models
{
    public class AllRestaurantsPageInfo
    {
        public int Restaurant_ID { get; set; }
        public string Soort_Keuken { get; set; }
        public Nullable<System.TimeSpan> Openingstijd { get; set; }
        public Nullable<System.TimeSpan> Slutingstijd { get; set; }
        public string Emailadres { get; set; }
        public string Naam { get; set; }
        public string Beschrijving_NL { get; set; }
        public string Beschrijving_EN { get; set; }
        public Nullable<double> Prijs { get; set; }
    }
}