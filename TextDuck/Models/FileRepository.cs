using System;
using System.Collections.Generic;
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
                var Status = (from k in Db.Files
                              where k.Status == "Process"
                              select k);
                return Status;
            }
            public IQueryable<srtFiles> GetTexts()
            {
                var Status = (from k in Db.Files
                              where k.Status == "Finished"
                              select k);
                return Status;
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

          
    }
     
}