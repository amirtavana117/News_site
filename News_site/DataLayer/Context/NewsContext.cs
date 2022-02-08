using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NewsContext :DbContext
    {
        public DbSet<News> news { get; set; }
        public DbSet<NewsComment> newsComments { get; set; }
        public DbSet<NewsGroups> newsGroups { get; set; }
    }
}
