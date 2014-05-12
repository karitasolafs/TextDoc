using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TextDuck.DAL;
using TextDuck.Models;
using TextDuck.UF;

namespace TextDuck.Controllers
{
    public class HomeController : Controller
    {
        FileRepository repo = new FileRepository();
        FileContext Db = new FileContext();
         
     
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

        public ActionResult Requests()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void AddLanguages()
        {
            List<SelectListItem> Language = new List<SelectListItem>();
            Language.Add(new SelectListItem { Text = "Veldu", Value = "Choose" });
            Language.Add(new SelectListItem { Text = "Enska", Value = "English" });
            Language.Add(new SelectListItem { Text = "Íslenska", Value = "Icelandic" });
            ViewBag.Language = Language;
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
    
        public ActionResult Status()
        {
            IQueryable<srtFiles> statusinn = (from item in repo.GetAllFiles()
                                              orderby item.Date
                                              where item.Status == "Process"
                                              select item).Take(10);
            return View(statusinn);
          
        }
        public ActionResult Subtitle()
        {
            IQueryable<srtFiles> statusinn = (from item in repo.GetAllFiles()
                                              orderby item.Date
                                              where item.Status == "Finished"
                                              select item);
            return View(statusinn);
        }
        public ActionResult Request()
        {
            IQueryable<srtFiles> statusinn = (from item in repo.GetAllFiles()
                                              orderby item.Date
                                              where item.Status == "Request"
                                              select item).Take(10);
            return View(statusinn);
        }
       
        public ActionResult TextBoxSrt(int? Id)
        {
            if (Id == null)
            {
                return View("Error");
                
            }
            srtFiles srt = Db.srtFiles.Find(Id);
            if (srt == null)
            {
                return View("Error");
       
            }
            return View(srt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TextBoxSrt([Bind(Include = "Id,Title,Content,Status,Date,Category,Genre,Language")] srtFiles srt)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(srt).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(srt);

        }
        [HttpGet]
        public ActionResult Create()
        {
            AddLanguages();
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
                    Status = item.FileStatus,
                    Language = item.FileLanguage

                };

                repo.AddFile(entityObj);
                repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                AddLanguages();
                AddCategories();
                AddGenre();
                return View(item);
           }
                //View(item);
           
        }
        public ActionResult ViewSrt(int id)
        {
            var statusinn = repo.GetFilesById(id).Content;
            Response.Clear();
            Response.ContentType = "Apllication/octet-stream"; ;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.hl7", id.ToString()));
            Response.Write(statusinn);
            Response.End();

            return File(Encoding.UTF8.GetBytes(statusinn), "Apllication/octet-stream", string.Format("{0}.hl7", id));
        }
    }

    
}
