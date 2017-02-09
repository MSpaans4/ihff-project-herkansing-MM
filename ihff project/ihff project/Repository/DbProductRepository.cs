﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ihff_project.Models;

namespace ihff_project.Repository
{
    public class DbProductRepository : IProductRepository
    {
        private iHFF1617S_B3E ctx = new iHFF1617S_B3E();

        public IEnumerable<AllFilmInfo> GetAllFilms()
        {
            var query = (from producten in ctx.Producten
                         join voorstellingen in ctx.Voorstellingen on producten.Product_ID equals voorstellingen.Product_ID
                         join films in ctx.Films on voorstellingen.Film_ID equals films.Film_ID
                         join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                         orderby voorstellingen.Dag ascending, voorstellingen.Start_Tijd ascending
                         select new AllFilmInfo()
                         {                          
                         }).ToList();

            return query;
        }

        public IEnumerable<AllFilmInfo> GetAllFilmsDag(int dag)
        {
            var query = (from producten in ctx.Producten
                        join voorstellingen in ctx.Voorstellingen on producten.Product_ID equals voorstellingen.Product_ID
                        join films in ctx.Films on voorstellingen.Film_ID equals films.Film_ID
                        join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                        where voorstellingen.Dag == dag
                        orderby voorstellingen.Start_Tijd ascending
                        select new AllFilmInfo()
                        {
                            

                        }).ToList();

            return query;
        }

        // Voor SessionBesteldeItem
        public AllFilmInfo GetFilmForSession(int productId)
        {
            var query = (from producten in ctx.Producten
                         join voorstellingen in ctx.Voorstellingen on producten.Product_ID equals voorstellingen.Product_ID
                         join films in ctx.Films on voorstellingen.Film_ID equals films.Film_ID
                         join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                         where producten.Product_ID == productId
                         select new AllFilmInfo()
                         {
                             

                         }).FirstOrDefault();

            return query;
        }

        public IEnumerable<Voorstellingen> GetAllVoorstellingenFilm(int filmId)
        {
            IEnumerable<Voorstellingen> allVoorstellingen = ctx.Voorstellingen.Where(c => c.Film_ID == filmId);
            return allVoorstellingen;
        }

        public IEnumerable<AllFilmInfo> GetVoorstellingen(int productId)
        {
            var query = (from producten in ctx.Producten
                         join voorstellingen in ctx.Voorstellingen on producten.Product_ID equals voorstellingen.Product_ID
                         join films in ctx.Films on voorstellingen.Film_ID equals films.Film_ID
                         join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                         where voorstellingen.Product_ID == productId
                         select new AllFilmInfo()
                         {
                             

                         }).ToList();

            return query;
        }

        public Films GetFilm(int filmId)
        {
            return ctx.Films.SingleOrDefault(c => c.Film_ID == filmId);
        }

        public Voorstellingen GetVoorstelling(int productId)
        {
            return ctx.Voorstellingen.SingleOrDefault(c => c.Product_ID == productId);
        }

        public void EditFilm(Films film)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllRestaurantsPageInfo> GetAllRestaurants()
        {
            var query = (from producten in ctx.Producten
                         join restaurants in ctx.Restaurants on producten.Product_ID equals restaurants.Restaurant_ID
                         join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                         select new AllRestaurantsPageInfo()
                         {
                             Naam = locaties.Locatie_Naam,
                             Soort_Keuken = restaurants.Soort_Keuken,
                             Restaurant_ID = restaurants.Restaurant_ID,
                             Openingstijd = restaurants.Openingstijd,
                             Slutingstijd = restaurants.Slutingstijd,
                             Beschrijving_EN = restaurants.Beschrijving_EN,
                             Beschrijving_NL = restaurants.Beschrijving_NL,
                             Prijs = producten.Prijs

                         }).ToList();

            return query;

        }

        public AllRestaurantsPageInfo GetRestaurant(int restaurantId)
        {
            var query = (from producten in ctx.Producten
                         join restaurants in ctx.Restaurants on producten.Product_ID equals restaurants.Restaurant_ID
                         join locaties in ctx.Locaties on producten.Locatie_ID equals locaties.Locatie_ID
                         where restaurants.Restaurant_ID == restaurantId
                         select new AllRestaurantsPageInfo()
                         {
                             Naam = locaties.Locatie_Naam,
                             Soort_Keuken = restaurants.Soort_Keuken,
                             Restaurant_ID = restaurants.Restaurant_ID,
                             Openingstijd = restaurants.Openingstijd,
                             Slutingstijd = restaurants.Slutingstijd,
                             Beschrijving_EN = restaurants.Beschrijving_EN,
                             Beschrijving_NL = restaurants.Beschrijving_NL,
                             Prijs = producten.Prijs


                         }).FirstOrDefault();

            return query;
        }

        public SessionBesteldeItem GetSessionBesteldeItem(int productId)
        {
            SessionBesteldeItem product = new SessionBesteldeItem();
        
            if (productId > 6)
            {
                product.Film = GetFilmForSession(productId);
                product.Product = productId;
                product.SoortProduct = 1;
            }
            else
            {
                product.Restaurant = GetRestaurant(productId);
                product.Product = productId;
                product.SoortProduct = 2;
            }
            return product;
        }

        public IEnumerable<Locaties> GetAllLocaties()
        {
            var v = ctx.Locaties.OrderBy(a => a.Locatie_Naam).ToList();
            return v;
        }
    }
}