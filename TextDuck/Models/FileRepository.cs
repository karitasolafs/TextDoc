using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.UF;

namespace TextDuck.Models
{
    public class FileRepository
    {
        public class NewsRepository
        {
            UploadContext Db = new UploadContext();

            public IQueryable<FileUpload> GetAllNews()
            {
                return Db.File;
            }

            public FileUpload GetNewsById(int id)
            {
                var result = (from s in Db.File
                              where s.FileId == id
                              select s).SingleOrDefault();
                return result;
            }

            public void AddNews(FileUpload s)
            {
                Db.File.Add(s);
                Db.SaveChanges();
            }

            public void Save()
            {
                Db.SaveChanges();
            }

            public void UpdateNews(FileUpload s)
            {
                FileUpload t = GetNewsById(s.FileId.Value);
                if (t != null)
                {
                    t.FileTitle = s.FileTitle;
                    t.FileContent = s.FileContent;
                    t.FileCategory = s.FileCategory;
                    Db.SaveChanges();
                }
            }
        }
    }
}