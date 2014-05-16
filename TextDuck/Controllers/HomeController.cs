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
        //New instance of FileRepository
        FileRepository repo = new FileRepository();
        //New instance of CommentRepository
        CommentRepository Comment = new CommentRepository();

        //Returns the home page of the site
        public ActionResult Index()
        {
            return View();
        }

        //Confirmation that the information about the file has been changed
        public ActionResult ChangesMade()
        {
            return View();
        }
        //Confirmation that a new Subtitle file has been added
        public ActionResult SubtitleMade()
        {
            return View();
        }
        //Confirmation that a new Request has been added
        public ActionResult RequestMade()
        {
            return View();
        }
        //Confirmation that the content of the file has been changed
        public ActionResult ChangesToFile()
        {
            return View();
        }
        //Returns the Help page
        public ActionResult Help()
        {
            return View();
        }
        //Returns the Contact page 
        public ActionResult Contact()
        {

            return View();
        }

        //Creates a drop down list for the language of the file
        private void AddLanguages()
        {
            List<SelectListItem> Language = new List<SelectListItem>();
            Language.Add(new SelectListItem { Text = "Veldu", Value = null });
            Language.Add(new SelectListItem { Text = "Enska", Value = "Enska" });
            Language.Add(new SelectListItem { Text = "Íslenska", Value = "Íslenska" });
            ViewBag.Language = Language;
        }
        //Creates a drop down list for the category of the file
        private void AddCategories()
        {
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.Add(new SelectListItem { Text = "Veldu", Value = null });
            Categories.Add(new SelectListItem { Text = "Bíómynd", Value = "Bíómynd" });
            Categories.Add(new SelectListItem { Text = "Þáttur", Value = "Þáttur" });
            ViewBag.Categories = Categories;
        }

        //Creates a drop down list for the genre of the file
        private void AddGenre()
        {
            List<SelectListItem> Genre = new List<SelectListItem>();
            Genre.Add(new SelectListItem { Text = "Veldu", Value = null });
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

        //Creates a drop down list for the status of the file
        private void AddStatus()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Veldu", Value = null });
            Status.Add(new SelectListItem { Text = "Beiðni", Value = "Beiðni" });
            Status.Add(new SelectListItem { Text = "Í vinnslu", Value = "Í vinnslu" });
            Status.Add(new SelectListItem { Text = "Lokið", Value = "Lokið" });
            ViewBag.Status = Status;
        }
        //Creates a drop down list for the status of the file that only allows you to pick request
        private void AddStatusRequest()
        {
            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "Beiðni", Value = "Beiðni" });
            ViewBag.Status = Status;
        }
        //A get function for all the comments
        public ActionResult Comments()
        {
            var comment = Comment.GetComment();
            return View(comment);
        }

        //Adds an upvote to a request
        public ActionResult AddVote(int Id)
        {
            var vote = repo.GetFilesById(Id);
                vote.Votes++;
                repo.SetModified(vote);
                repo.Save();
                
                return RedirectToAction("Request");     
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Í vinnslu" by name
        public ActionResult Status()
        {
            var status = repo.GetStatus();
            return View(status);
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Lokið" by name
        public ActionResult Subtitle()
        {
            var subtitle = repo.GetTexts();
            return View(subtitle);
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Lokið" by date
        public ActionResult SubtitleDate()
        {
            var date = repo.GetTextsByDate();
            return View(date);
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Lokið" by genre
        public ActionResult SubtitleGenre()
        {
            var genre = repo.GetTextsByGenre();
            return View(genre);
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Lokið" by category
        public ActionResult SubtitleCategory()
        {
            var cat = repo.GetTextsByCategory();
            return View(cat);
        }

        //Calls a function in the repository that orders the .srt files with the status
        //"Lokið" by language
        public ActionResult SubtitleLanguage()
        {
            var lang = repo.GetTextsByLanguage();
            return View(lang);
        }
        //Calls a function in the repository that orders the .srt files with the status
        //"Beiðni" by votes
        public ActionResult Request()
        {
            var request = repo.GetRequest();
            return View(request);
        }

        //The get function for uploading a .srt file

        [Authorize] //Only "Innskráðir notendur" can access this function
        [HttpGet]
        public ActionResult Create()
        {
            AddLanguages();
            AddCategories();
            AddGenre();
            AddStatus();
            return View(new FileUpload());
        }

        //The post function for uploading a file
        [HttpPost]
        public ActionResult Create(FileUpload item)
        {
            if (ModelState.IsValid)
            {
               //Reads the .srt file content into a string
                var b = new System.IO.BinaryReader(item.File.InputStream);
                byte[] binData = b.ReadBytes((int)item.File.InputStream.Length);
                string result = System.Text.Encoding.UTF8.GetString(binData);

                System.Diagnostics.Debug.Write(result);

                //Constructor for srtFiles
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
                //Saves the object into the database
                repo.AddFile(entityObj);
                repo.Save();
                return RedirectToAction("SubtitleMade");
            }
            else
            {
                //if the model is not valid it loads the view again
                AddLanguages();
                AddCategories();
                AddGenre();
                AddStatus();
                return View(item);
            }
        }

        //The get function for uploading requests
        public ActionResult CreateRequest()
        {
            AddLanguages();
            AddCategories();
            AddGenre();
            AddStatusRequest();
            return View(new FileUpload());
        }

        //The post function for uploading requests 
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
                return RedirectToAction("RequestMade");
            }
            else
            {
                AddLanguages();
                AddCategories();
                AddGenre();
                AddStatusRequest();
                return View(item);
            }
        }
        //The get function for editing the file
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
        //The post function for the content of the file for editing
        //Saves the changes to the file to the database
        [HttpPost]
        public ActionResult TextBoxSrt([Bind(Include = "Id,Title,Content,Status,Date,Category,Genre,Language")] srtFiles srt)
        {
            if (ModelState.IsValid)
            {
                repo.SetModified(srt);
                repo.Save();
                return RedirectToAction("ChangesToFile");
            }
            return View(srt);

        }
        //The function that allows you to download the file to your computer
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
    
        //A function that changes the status of the file from "Beiðni" to "Í vinnslu"
        //Saves the changes to the database
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
        //The get function for changing the information about the file
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
        //The post function for changing the information about the file
        //Saves the changes to the database
        [HttpPost]
        public ActionResult FileAppearanceChanges([Bind(Include = "Id,Title,Content,Status,Date,Category,Genre,Language")] srtFiles skra)
        {
            if (ModelState.IsValid)
            {
                repo.SetModified(skra);
                repo.Save();
                return RedirectToAction("ChangesMade");
            }

            return View(skra);
        }

        //The function that gets the srtId and the srtTitle for the view ViewComment
        [Authorize]
        [HttpGet]
        public ActionResult AddComment(int Id, string Title)
        {
            return View(new CommentItem() { srtId = Id, srtTitle = Title });

        }
        //The get function for the comments
        [Authorize]
        [HttpGet]
        public ActionResult ViewComment()
        {
            return View(Comment.GetComment());
        }

        //The function that saves the comments to the database and returns the ViewComment view
        [HttpPost]
        public ActionResult AddComment(FormCollection form)
        {
            CommentItem item = new CommentItem();
            UpdateModel(item);
            item.UserName = User.Identity.Name;
            item.DateCreated = DateTime.Now;
            Comment.AddComment(item);
            Comment.Save();
            return RedirectToAction("ViewComment");

        }
        //The function that accepts a string from the user
        //Calls the help function Search 
        [HttpPost]
        public ActionResult SearchResult(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                var all = repo.GetAllFiles();
                var searched = Search(all, query);
                return View(searched);
            }
            return RedirectToAction("Subtitle");
        }
        //checks if the string that SearchResult accepts excists in the database
        //also a helper function for unit testing 
        public IQueryable<srtFiles> Search(IQueryable<srtFiles> all, string query)
        {
            return from item in all
                   orderby item.Title ascending
                   where item.Title.Contains(query)
                   select item;
        }


    }
}
