using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff_project.Models;
using ihff_project.Repository;

namespace ihff_project.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository homeRepository = new DbHomeRepository();

        public ActionResult Index()
        {
            IEnumerable<Producten> highlights = homeRepository.GetAllHighlights();
            return View(highlights);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}