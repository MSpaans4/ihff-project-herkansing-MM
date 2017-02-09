using ihff_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff_project.Repository
{
    public class DbHomeRepository : IHomeRepository
    {
        private iHFF1617S_B3E ctx = new iHFF1617S_B3E();

        public IEnumerable<Producten> GetAllHighlights()
        {
            return ctx.Producten.Where(c => c.Highlight == true).ToList();
        }
    }
}