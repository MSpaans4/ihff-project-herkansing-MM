using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff_project.Repository;
using ihff_project.Models;

namespace ihff_project.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository = new DbProductRepository();
        public List<SessionBesteldeItem> productsSession = new List<SessionBesteldeItem>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test2()
        {
            IEnumerable<AllRestaurantsPageInfo> restaurants = productRepository.GetAllRestaurants();
            return View(restaurants);
        }

        public ActionResult Events(int dag)
        {
            IEnumerable<AllFilmInfo> filmList;

            if (dag >= 3 && dag <= 7)
                filmList = productRepository.GetAllFilmsDag(dag);
            else
                filmList = productRepository.GetAllFilms();

            switch(dag)
            {
                case 3:
                    ViewBag.Dag = "Wednesday";
                    break;
                case 4:
                    ViewBag.Dag = "Thursday";
                    break;
                case 5:
                    ViewBag.Dag = "Friday";
                    break;
                case 6:
                    ViewBag.Dag = "Saterday";
                    break;
                case 7:
                    ViewBag.Dag = "Sunday";
                    break;
                default:
                    ViewBag.Dag = "the programme";
                    break;
            }
                
            return View(filmList);
        }

        [HttpGet]
        public ActionResult Restaurants()
        {
            IEnumerable<AllRestaurantsPageInfo> restaurants = productRepository.GetAllRestaurants();

            if (HttpContext.Session["products"] == null)
            {
                HttpContext.Session["products"] = productsSession;

            }

            ViewBag.test = "Content Restaurant. De Database moet nog gevuld worden betreffende de beschrijving in NL en EN. Voor testdoeleinden is dit alleen voldoende om te laten zien wat de tekst doet.";
            return View(restaurants);
        }


        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Buy")]
        public ActionResult Buy(AllFilmInfo film)
        {
            return RedirectToAction("Events");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Programme")]
        public ActionResult Programme(AllFilmInfo film)
        {
            return RedirectToAction("Events");
        }

        
        public ActionResult Cultuur()
        {
            IEnumerable<Locaties> l = productRepository.GetAllLocaties();
            return View(l);
        }

        public ActionResult FilmDetail(int product_ID)
        {
            IEnumerable<AllFilmInfo> film = productRepository.GetVoorstellingen(product_ID);
            return View(film.First<AllFilmInfo>());
        }

        public ActionResult RestaurantDetail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddToProgramme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToProgramme(string idstr)
        {
            idstr = idstr.Replace("pr-", "");
            int id = int.Parse(idstr);

            SessionBesteldeItem r = productRepository.GetSessionBesteldeItem(id);
            r.Zaal13_Codes = "3";
            r.PersonalProgrammeOrShoppingCart = 1;
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];
            productsSession.Add(r);
            HttpContext.Session["products"] = productsSession;

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveFromProgramme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveFromProgramme(string productId)
        {
            string productIdstr = productId.Replace("prod-", "");
            int id = int.Parse(productIdstr);
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];

            HttpContext.Session["products"] = productsSession.Where(x => x.Product != id).ToList();

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RefreshPersonalProgramme()
        {
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];
            HttpContext.Session["products"] = productsSession;
            return PartialView("_PersonalProgramme");
        }

        [HttpGet]
        public ActionResult AddToCart()
        {
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];

            foreach (SessionBesteldeItem item in productsSession)
            {
                item.PersonalProgrammeOrShoppingCart = 2;
            }
            
            HttpContext.Session["products"] = productsSession;

            return View("ShoppingCart");
        }

        [HttpGet]
        public ActionResult AddEventToCart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventToCart(string idstr)
        {
            string productId = idstr.Replace("pr-", "");
            int id = int.Parse(productId);
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];

            

            SessionBesteldeItem r = productRepository.GetSessionBesteldeItem(id);
            r.PersonalProgrammeOrShoppingCart = 2;
            // productsSession.Add(r);

            HttpContext.Session["products"] = productsSession;

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddToShoppingCart()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShoppingCart()
        {
            return View("ShoppingCart");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PaymentSuccess()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClearShoppingCartSession()
        {
            productsSession = (List<SessionBesteldeItem>)HttpContext.Session["products"];

            HttpContext.Session["products"] = productsSession.Where(x => x.PersonalProgrammeOrShoppingCart == 1).ToList();
 
            return View("PaymentSuccess");
        }

    }
}