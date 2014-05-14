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
        CommentRepository Comment = new CommentRepository();

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
            Language.Add(new SelectListItem { Text = "Veldu", Value = "Veldu" });
            Language.Add(new SelectListItem { Text = "Enska", Value = "Enska" });
            Language.Add(new SelectListItem { Text = "Íslenska", Value = "Íslenska" });
            ViewBag.Language = Language;
        }
        private void AddCategories()
        {
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Veldu", Value = "Veldu" });
            Categories.Add(new SelectListItem { Text = "Bíómynd", Value = "Bíómynd" });
            Categories.Add(new SelectListItem { Text = "Þáttur", Value = "Þáttur" });
            ViewBag.Categories = Categories;
        }

        private void AddGenre()
        {
            List<SelectListItem> Genre = new List<SelectListItem>();
            Genre.Add(new SelectListItem { Text = "Veldu", Value = "Veldu" });
            Genre.Add(new SelectListItem { Text = "Hasar", Value = "Hasar" });
            Genre.Add(new SelectListItem { Text = "Gaman", Value = "Gaman" });
            Genre.Add(new SelectListItem { Text = "Rómantík", Value = "Rómantík" });
            Genre.Add(new SelectListItem { Text = "Drama", Value = "Drama" });
            Genre.Add(new SelectListItem { Text = "Spennu", Value = "Spennutryllir" });
            Genre.Add(new SelectListItem { Text = "Barna", Value = "Barna" });
            Genre.Add(new SelectListItem { Text = "Hryllings", Value = "Hryllings" });
            Genre.Add(new SelectListItem { Text = "Heimilda", Value = "Heimildamynd" });

            ViewBag.Genre = Genre;
        }

        private void AddStatus()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Veldu", Value = "Veldu" });
            Status.Add(new SelectListItem { Text = "Beiðni", Value = "Beiðni" });
            Status.Add(new SelectListItem { Text = "Í vinnslu", Value = "Í vinnslu" });
            Status.Add(new SelectListItem { Text = "Lokið", Value = "Lokið" });
            ViewBag.Status = Status;
        }

        private void AddStatusRequest()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Beiðni", Value = "Beiðni" });
            ViewBag.Status = Status;
        }

        public ActionResult Comments()
        {
            var comment = Comment.GetNews();
            return View(comment);
        }

        public ActionResult Status()
        {
            var statusinn = repo.GetStatus();
            return View(statusinn);

        }
        public ActionResult Subtitle()
        {
            var statusinn = repo.GetTexts();
            return View(statusinn);
        }
        public ActionResult Request()
        {
            var statusinn = repo.GetRequest();
            return View(statusinn);
        }

        [Authorize]
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
                AddStatus();
                return View(item);
            }
            //View(item);

        }

        public ActionResult CreateRequest()
        {
            AddLanguages();
            AddCategories();
            AddGenre();
            AddStatusRequest();
            return View(new FileUpload());
        }

        [HttpPost]
        public ActionResult CreateRequest(FileUpload item)
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
                AddStatusRequest();
                return View(item);
            }
            //View(item);

        }

        [Authorize]
        public ActionResult TextBoxSrt(int Id)
        {
            if (Id == null)
            {
                return View("Error");

            }

            var srt = repo.GetFilesById(Id);
            if (srt == null)
            {
                return View("Error");

            }
            return View(srt);
        }

        [HttpPost]
        public ActionResult TextBoxSrt([Bind(Include = "Id,Title,Content,Status,Date,Category,Genre,Language")] srtFiles srt)
        {
            if (ModelState.IsValid)
            {
                repo.SetModified(srt);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(srt);

        }
        public ActionResult ViewSrt(int id)
        {
            var statusinn = repo.GetFilesById(id).Content;
            Response.Clear();
            Response.ContentType = "Apllication/octet-stream"; ;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.srt", id.ToString()));
            Response.Write(statusinn);
            Response.End();

            return File(Encoding.UTF8.GetBytes(statusinn), "Apllication/octet-stream", string.Format("{0}.srt", id));
        }
    

        [Authorize]
        public ActionResult RequestMoved(int Id)
        {
            if (Id == null)
            {
                return View("Error");

            }

            srtFiles srt = repo.GetFilesById(Id);
            if (srt == null)
            {
                return View("Error");

            }
            srt.Status = "Í vinnslu";
            repo.Save();
            return View();
        }

        [Authorize]
        public ActionResult FileAppearanceChanges(int Id)
        {
            if (Id == null)
            {
                return View("Error");

            }

            srtFiles skra = repo.GetFilesById(Id);
            if (skra == null)
            {
                return View("Error");

            }
            return View(skra);
        }
        [HttpPost]
        public ActionResult FileAppearanceChanges([Bind(Include = "Id,Title,Content,Status,Date,Category,Genre,Language")] srtFiles skra)
        {
            if (ModelState.IsValid)
            {
                repo.SetModified(skra);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(skra);

        }
        [Authorize]
        [HttpGet]
        public ActionResult AddComment(int Id)
        {
            return View(new CommentItem() { srtId = Id });

        }
        [Authorize]
        [HttpGet]
        public ActionResult ViewComment()
        {
            return View(Comment.GetNews());
        }

        [HttpPost]
        public ActionResult AddComment(FormCollection form)
        {
            CommentItem item = new CommentItem();
            UpdateModel(item);
            item.UserName = User.Identity.Name;
            Comment.AddNews(item);
            Comment.Save();
            return RedirectToAction("ViewComment");
        }

        [HttpPost]
        public ActionResult SearchResult(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                var all = repo.GetAllFiles();
                var result = (from item in all
                              orderby item.Date
                              where item.Title.Contains(query)
                              select item);
                return View(result);
            }
            return View("Index");
        }

    }
}
