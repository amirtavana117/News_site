using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsGroupRepository : INewsGroupRepository
    {

        NewsContext db ;
        public NewsGroupRepository(NewsContext context)
        {
            this.db = context;
        }
        public IEnumerable<NewsGroups> GetAllNewsGroups()
        {
            return db.newsGroups;
        }

        public NewsGroups GetNewsById(int id)
        {
            return db.newsGroups.Find(id);
        }

        public bool insertNewsGroup(NewsGroups newsGroups)
        {
            try
            {
                db.newsGroups.Add(newsGroups);
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }
        public bool updateNewsGroup(NewsGroups newsGroups)
        {
            try
            {
                db.Entry(newsGroups).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteNewsGroup(NewsGroups newsGroups)
        {
            try
            {
                db.Entry(newsGroups).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNewsGroup(int newsGroupId)
        {
            try
            {
                var newsGroup = GetNewsById(newsGroupId);
                DeleteNewsGroup(newsGroup);
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
