using System;
using TextDuck.UF;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace TextDuck.Models
{
    public class CommentRepository
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        public IQueryable<CommentItem> GetAllComments()
        {
            return m_db.Comments.AsQueryable();
        }

        public IQueryable<CommentItem> GetComment()
        {
            var Comment = (from x in m_db.Comments
                        orderby x.DateCreated descending
                        where x.UserName != null && x.srtId != null
                        select x);
            return Comment;
        }
        public CommentItem GetCommentsById(int? id)
        {
            var result = (from s in m_db.Comments
                          where s.Id == id                   
                          select s).SingleOrDefault();          
            return result;                                              
        }

        public void AddComment(CommentItem s)
        {
            m_db.Comments.Add(s);
            m_db.SaveChanges();
        }
        public void Save()
        {
            m_db.SaveChanges();
        }

        public void UpdateComment(CommentItem s)
        {
            CommentItem t = GetCommentsById(s.Id);
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