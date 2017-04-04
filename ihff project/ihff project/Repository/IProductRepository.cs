using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihff_project.Models;

namespace ihff_project.Repository
{
    interface IProductRepository
    {
        IEnumerable<AllFilmInfo> GetAllFilmsDag(int dag);
        IEnumerable<AllFilmInfo> GetAllFilms();
        AllFilmInfo GetFilmForSession(int productId);
        IEnumerable<Voorstellingen> GetAllVoorstellingenFilm(int filmId);
        AllFilmInfo GetVoorstellingen(int productId);
        Films GetFilm(int filmId);
        Voorstellingen GetVoorstelling(int productId);
        IEnumerable<AllRestaurantsPageInfo> GetAllRestaurants();
        AllRestaurantsPageInfo GetRestaurant(int restaurantId);
        SessionBesteldeItem GetSessionBesteldeItem(int productId);
        IEnumerable<Locaties> GetAllLocaties();
        IEnumerable<AllCultureInfo> GetCultureInfo();
        IEnumerable<Producten> GetAllHighlights();
        IEnumerable<AllFilmInfo> GetAllLecture();
        IEnumerable<AllFilmInfo> GetAllMovies();
    }
}
