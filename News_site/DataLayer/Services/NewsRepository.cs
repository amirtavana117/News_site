using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsRepository : INewsRepository
    {


        NewsContext db = new NewsContext();
        public IEnumerable<News> GetAllNewsREpository()
        {
            return db.news;
        }

        public News GetNewsById(int id)
        {
            return db.news.Find(id);
        }

        public bool insertNews(News news)
        {
            try
            {
                db.news.Add(news);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool updateNews(News news)
        {
            try
            {
                db.Entry(news).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
      

        public bool DeleteNews(News news)
        {
            try
            {
                db.Entry(news).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNews(int newsId)
        {
            try
            {
                var news  = GetNewsById(newsId);
                DeleteNews(news);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
        public void save()
        {
            db.SaveChanges();
        }

    }
}
