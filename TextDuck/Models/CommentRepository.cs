using System;
using TextDuck.UF;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class CommentRepository
    {
         CommentContext m_db = new CommentContext();

        public IQueryable<CommentItem> GetAllNews()
        {
            return m_db.Comment;
        }

        public CommentItem GetNewsById(int id)
        {
            var result = (from s in m_db.Comment
                          where s.Id == id
                          select s).SingleOrDefault();
            return result;
        }

        public void AddComment(CommentItem s)
        {
            m_db.Comment.Add(s);
            m_db.SaveChanges();
        }

        public void Save()
        {
            m_db.SaveChanges();
        }

      /*  public void UpdateNews(CommentItem s)
        {
            NewsItem t = GetNewsById(s.Id.Value);
            if(t != null)
            {
                t.Title = s.Title;
                t.Text = s.Text;
                t.Category = s.Category;
                m_db.SaveChanges();
            }
        }*/
    }
}