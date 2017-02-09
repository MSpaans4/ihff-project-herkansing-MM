using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihff_project.Models;

namespace ihff_project.Repository
{
    interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        Film GetFilm(int filmId);
        void EditFilm(Film film);
    }
}
