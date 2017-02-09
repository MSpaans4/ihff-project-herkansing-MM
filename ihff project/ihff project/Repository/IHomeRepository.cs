using ihff_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihff_project.Repository
{
    interface IHomeRepository
    {
        IEnumerable<Producten> GetAllHighlights();
    }
}
