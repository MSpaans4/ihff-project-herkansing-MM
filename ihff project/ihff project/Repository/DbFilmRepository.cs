using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ihff_project.Models;

namespace ihff_project.Repository
{
    public class DbFilmRepository : IFilmRepository
    {
        private DatabaseContext ctx = new DatabaseContext();

        public IEnumerable<Film> GetAllFilms()
        {
            IEnumerable<Film> allFilms = ctx.Films;
            return allFilms;
        }

        public Film GetFilm(int filmId)
        {
            return ctx.Films.SingleOrDefault(c => c.Film_ID == filmId);
        }

        public void EditFilm(Film film)
        {
            throw new NotImplementedException();
        }
    }
}