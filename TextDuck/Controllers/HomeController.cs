using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextDuck.Models;
using TextDuck.UF;

namespace TextDuck.Controllers
{
    public class HomeController : Controller
    {
         FileRepository repo = new FileRepository();
         
     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hjalp()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Subtitles()
        {
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
            Categories.Add(new SelectListItem { Text = "Veldu", Value = "Choose" });
            Categories.Add(new SelectListItem { Text = "Bíómynd", Value = "Movie" });
            Categories.Add(new SelectListItem { Text = "Þáttur", Value = "TvShow" });
            ViewBag.Categories = Categories;
        }

        private void AddGenre()
        {
            List<SelectListItem> Genre = new List<SelectListItem>();
            Genre.Add(new SelectListItem{Text = "Veldu", Value = "Choose"});
            Genre.Add(new SelectListItem { Text = "Hasar", Value = "Action" });
            Genre.Add(new SelectListItem { Text = "Gaman", Value = "Comedy" });
            Genre.Add(new SelectListItem { Text = "Rómantík", Value = "Romance" });
            Genre.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
            Genre.Add(new SelectListItem { Text = "Spennu", Value = "Thriller" });
            Genre.Add(new SelectListItem { Text = "Barna", Value = "Children" });
            Genre.Add(new SelectListItem { Text = "Hryllings", Value = "Horror" });
            Genre.Add(new SelectListItem { Text = "Heimilda", Value = "Documentary" });

            ViewBag.Genre = Genre;
        }

        private void AddStatus()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Veldu", Value = "Choose" });
            Status.Add(new SelectListItem { Text = "Beiðni", Value = "Request" });
            Status.Add(new SelectListItem { Text = "Í vinnslu", Value = "Process" });
            Status.Add(new SelectListItem { Text = "Lokið", Value = "Finished" });
            ViewBag.Status = Status;
        }
        [HttpGet]
        public ActionResult IVinnslu()
        {
            IQueryable<srtFiles> statusinn = (from item in repo.GetAllFiles()
                                              orderby item.Status
                                              where item.Title != null
                                              select item).Take(10);
            return View(statusinn);
          
        }

        [HttpGet]
        public ActionResult Create()
        {
            AddCategories();
            AddGenre();
            AddStatus();
            return View(new FileUpload());
        }

        [HttpPost]
        public ActionResult Create(FileUpload item)
        {
          if (ModelState.IsValid)
            {
                var b = new System.IO.BinaryReader(item.File.InputStream);
                byte[] binData = b.ReadBytes((int)item.File.InputStream.Length);
                string result = System.Text.Encoding.UTF8.GetString(binData);

                System.Diagnostics.Debug.Write(result);

                var entityObj = new srtFiles
                {
                    Title = item.FileTitle,
                    Content = result,
                    Date = DateTime.Now,
                    Category = item.FileCategory,
                    Genre = item.FileGenre,
                    Status = item.FileStatus
                };

                repo.AddFile(entityObj);
                repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                AddCategories();
                AddGenre();
                return View(item);
           }
                //View(item);
        }
    }
}