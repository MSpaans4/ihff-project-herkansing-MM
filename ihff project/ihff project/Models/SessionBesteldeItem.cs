using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff_project.Models
{
    public class SessionBesteldeItem
    {
        public int Product { get; set; }
        public int Aantal { get; set; }
        public double Prijs { get; set; }
        public string Zaal13_Codes { get; set; }

        public AllRestaurantsPageInfo Restaurant { get; set; }
        public AllFilmInfo Film { get; set; }
        public Cultuur Cultuur { get; set; }

        // 1 = personal, 2 = shopping
        public int PersonalProgrammeOrShoppingCart { get; set; }

        // 1 = Film/Special 2 = Restaurant 3 = Cultuur
        public int SoortProduct { get; set; }
    }
}