using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextDuck.Models
{
    public class FileRepository
    {
        public class NewsRepository
        {
            NewsContext m_db = new NewsContext();

            public IQueryable<NewsItem> GetAllNews()
            {
                return m_db.News;
            }

            public NewsItem GetNewsById(int id)
            {
                var result = (from s in m_db.News
                              where s.Id == id
                              select s).SingleOrDefault();
                return result;
            }

            public void AddNews(NewsItem s)
            {
                m_db.News.Add(s);
                m_db.SaveChanges();
            }

            public void Save()
            {
                m_db.SaveChanges();
            }

            public void UpdateNews(NewsItem s)
            {
                NewsItem t = GetNewsById(s.Id.Value);
                if (t != null)
                {
                    t.Title = s.Title;
                    t.Text = s.Text;
                    t.Category = s.Category;
                    m_db.SaveChanges();
                }
            }
        }
    }
}