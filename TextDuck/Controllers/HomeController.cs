using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextDuck.Models;

namespace TextDuck.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        private void AddCategories()
        {
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Movie", Value = "Movie" });
            Categories.Add(new SelectListItem { Text = "TvShow", Value = "TvShow" });
            ViewBag.Categories = Categories;
        }

        [HttpGet]
        public ActionResult Create()
        {
            AddCategories();
            return View(new FileUpload());
        }

        [HttpPost]
        public ActionResult Create(FileUpload item)
        {
            if (ModelState.IsValid)
            {
                item.FileDate = DateTime.Now;
                repo.AddNews(item);
                repo.Save();
                return RedirectToAction("Index");
            }

            AddCategories();
            return View(item);
        }
    }
}