using System;
using TextDuck.UF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextDuck.DAL;


namespace TextDuck.Models
{
    public class CommentRepository
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        public IQueryable<CommentItem> GetAllNews()
        {
            return m_db.comment;
        }

        public IQueryable<CommentItem> GetNews()
        {
            var News = (from x in m_db.comment
                        orderby x.DateCreated
                        select x);
            return News;
        }
        public CommentItem GetNewsById(int id)
        {
            var result = (from s in m_db.comment                 
                          where s.Id == id                      
                          select s).SingleOrDefault();          
            return result;                                              
        }

        public void AddNews(CommentItem s)
        {
            m_db.Comments.Add(s);
            m_db.SaveChanges();
        }
        public void Save()
        {
            m_db.SaveChanges();
        }

        public void UpdateNews(CommentItem s)
        {
            CommentItem t = GetNewsById(s.Id);
            if (t != null)
            {
                t.Title = s.Title;
                t.Text = s.Text;
                m_db.SaveChanges();
            }
        }

       // public DateTime LastModifiedDate { get; set; }

     
    }
    
}