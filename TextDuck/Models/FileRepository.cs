using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.UF;

namespace TextDuck.Models
{
    public class FileRepository
    {
            UploadContext Db = new UploadContext();

            public IQueryable<FileUpload> GetAllFiles()
            {
                return Db.File;
            }

            public FileUpload GetFilesById(int id)
            {
                var result = (from s in Db.File
                              where s.FileId == id
                              select s).SingleOrDefault();
                return result;
            }

            public void AddFile(FileUpload s)
            {
                Db.File.Add(s);
                Db.SaveChanges();
            }

            public void Save()
            {
                Db.SaveChanges();
            }

            public void UpdateFile(FileUpload s)
            {
                FileUpload t = GetFilesById(s.FileId.Value);
                if (t != null)
                {
                    t.FileTitle = s.FileTitle;
                    t.FileCategory = s.FileCategory;
                    t.FileGenre = s.FileGenre;
                    Db.SaveChanges();
                }
            }

            public void AddFile(srtFiles entityObj)
            {
              //  Db.File2.Add(entityObj);
                Db.SaveChanges();
                
               // throw new NotImplementedException();
            }
    }
     
}