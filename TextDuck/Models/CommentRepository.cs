using System;
using TextDuck.UF;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace TextDuck.Models
{
    public class CommentRepository
    {
        // new instance of ApplicationDbContext
        ApplicationDbContext m_db = new ApplicationDbContext();
        //Get all comments from the database
        public IQueryable<CommentItem> GetAllComments()
        {
            return m_db.Comments.AsQueryable();
        }
        //Gets comments from the database orderd by Date
        public IQueryable<CommentItem> GetComment()
        {
            var Comment = (from x in m_db.Comments
                        orderby x.srtId
                        where x.UserName != null && x.srtId != null
                        select x);
            return Comment;
        }
        //Gets comments from the database where the id on the srt File is the same as the id in the database
        public CommentItem GetCommentsById(int? id)
        {
            var result = (from s in m_db.Comments
                          where s.Id == id                   
                          select s).SingleOrDefault();          
            return result;                                              
        }
        // Adds the comment to the database
        public void AddComment(CommentItem s)
        {
            m_db.Comments.Add(s);
            m_db.SaveChanges();
        }
        //Saves the comment to the database
        public void Save()
        {
            m_db.SaveChanges();
        }
     

    }
    
}