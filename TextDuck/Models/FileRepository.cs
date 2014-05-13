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
            ApplicationDbContext Db = new ApplicationDbContext();

            public IQueryable<srtFiles> GetAllFiles()
            {
                return Db.Files;
            }

            public IQueryable<srtFiles> GetStatus()
            {
                var Status = (from item in Db.Files
                             orderby item.Date
                              where item.Status == "Í vinnslu"
                             select item).Take(10);
                return Status;
            }
            public IQueryable<srtFiles> GetTexts()
            {
                var Text = (from item in Db.Files
                           orderby item.Date
                            where item.Status == "Lokið"
                           select item);
                return Text;
            }
            public IQueryable<srtFiles> GetRequest()
            {
                var request = (from item in Db.Files
                               orderby item.Date
                               where item.Status == "Beiðni"
                               select item).Take(10);
                return request;
            }

            public srtFiles GetFilesById(int id)
            {
                var result = (from s in Db.Files
                              where s.Id == id
                              select s).SingleOrDefault();
                return result;
            }
            

            public void AddFile(srtFiles s)
            {
                Db.Files.Add(s);
                Db.SaveChanges();
            }

            public void Save()
            {

                Db.SaveChanges();
            }

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
            public void SetModified(object entity)
            {
               
                    Db.Entry(entity).State = EntityState.Modified;
               
                
            }

    }
     
}