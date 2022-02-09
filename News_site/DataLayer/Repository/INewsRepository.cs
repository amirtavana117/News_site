using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface INewsRepository :IDisposable
    {
        IEnumerable<News> GetAllNewsREpository();
        News GetNewsById(int id);
        bool insertNews(News news);
        bool updateNews(News news);
        bool DeleteNews(News news);
        bool DeleteNews(int newsId);
        void save();

    }
}
