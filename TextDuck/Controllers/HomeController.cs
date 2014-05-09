﻿using System;
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
        //blah með h-i og logo heyhey
        //blah blah comment
        //gaman gaman
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Hjalp()
        {
           // ViewBag.Message = "Your application description page.";

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



        [HttpGet]
        public ActionResult Create()
        {
            AddCategories();
            AddGenre();
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

                var entityObj = new Smuuuu
                {
                    Title = item.FileTitle,
                    Contents = result
                };

                item.FileDate = DateTime.Now;
                repo.AddFile(item);
                repo.Save();
                return RedirectToAction("Create");
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