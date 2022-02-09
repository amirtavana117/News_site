using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface INewsGroupRepository :IDisposable
    {
        IEnumerable<NewsGroups> GetAllNewsGroups();
        NewsGroups GetNewsById(int id);
        bool insertNewsGroup(NewsGroups newsGroups);
        bool updateNewsGroup(NewsGroups newsGroups);
        bool DeleteNewsGroup(NewsGroups newsGroups);
        bool DeleteNewsGroup(int newsGroupId);
        void save();

    }
}
