using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TextDuck.Models.Entities;
using TextDuck.UF;

namespace TextDuck.Models
{
    public class FileRepository 
    {
            //New instance of ApplicationDbContext
            ApplicationDbContext Db = new ApplicationDbContext();
            //Gets all files from the database
            public IQueryable<srtFiles> GetAllFiles()
            {
                return Db.Files;
            }
            // Gets Files from the database orderd by Title, that have the status "Í vinnslu"
            public IQueryable<srtFiles> GetStatus()
            {
                var Status = (from item in Db.Files
                             orderby item.Title ascending
                             where item.Status == "Í vinnslu"
                             select item).Take(10);
                return Status;
            }
            // Gets Files from the database orderd by Title, that have the status "Lokið"
            public IQueryable<srtFiles> GetTexts()
            {
                var Text = (from item in Db.Files
                            orderby item.Title ascending
                            where item.Status == "Lokið"
                           select item);
                return Text;
            }
            // Gets Files from the database orderd by date, that have the status "Lokið"
            public IQueryable<srtFiles> GetTextsByDate()
            {
                var Text = (from item in Db.Files
                            orderby item.Date descending
                            where item.Status == "Lokið"
                            select item);
                return Text;
            }
            // Gets Files from the database orderd by genre, that have the status "Lokið"
            public IQueryable<srtFiles> GetTextsByGenre()
            {
                var Text = (from item in Db.Files
                            orderby item.Genre ascending
                            where item.Status == "Lokið"
                            select item);
                return Text;
            }
            // Gets Files from the database orderd by category, that have the status "Lokið"
            public IQueryable<srtFiles> GetTextsByCategory()
            {
                var Text = (from item in Db.Files
                            orderby item.Category ascending
                            where item.Status == "Lokið"
                            select item);
                return Text;
            }
            // Gets Files from the database orderd by language, that have the status "Lokið"
            public IQueryable<srtFiles> GetTextsByLanguage()
            {
                var Text = (from item in Db.Files
                            orderby item.Language ascending
                            where item.Status == "Lokið"
                            select item);
                return Text;
            }
            // Gets Files from the database orderd by votes, that have the status "Beiðni"
            public IQueryable<srtFiles> GetRequest()
            {
                var request = (from item in Db.Files
                               orderby item.Votes descending
                               where item.Status == "Beiðni"
                               select item);
                return request;
            }
            // Gets Files from the database where the id on the srt file is the same as the id in the database
            public srtFiles GetFilesById(int? id)
            {
                var result = (from s in Db.Files
                              where s.Id == id
                              select s).SingleOrDefault();
                return result;
            }
            
            //Adds files to the database
            public void AddFile(srtFiles s)
            {
                Db.Files.Add(s);
                Db.SaveChanges();
            }
            //Saves a file to the database
            public void Save()
            {

                Db.SaveChanges();
            }
            //Updates the file 
            public void UpdateFile(srtFiles s)
            {
                srtFiles t = GetFilesById(s.Id);
                if (t != null)
                {
                    t.Title = s.Title;
                    t.Category = s.Category;
                    t.Genre = s.Genre;
                    Db.SaveChanges();
                }
            }
            //Sets status of the file to modified in the database
            public void SetModified(object entity)
            {
               
                    Db.Entry(entity).State = EntityState.Modified;
                           
            }

            // throws NotImplementedException 
            public object GetTexts(IQueryable<srtFiles> data, string p)
            {
                throw new NotImplementedException();
            }
    }
     
}