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
        private IProductRepository productRepository = new DbProductRepository();

        public ActionResult Index()
        {
            IEnumerable<Producten> highlights = productRepository.GetAllHighlights();
            return View(highlights);
        }
    }
}