using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace News_site.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository newsRepository;
        private  INewsGroupRepository newsGroupRepository;
        private NewsContext db = new NewsContext();
        public NewsController()
        {
            newsGroupRepository = new NewsGroupRepository(db);
            newsRepository = new NewsRepository(db);
        }

        // GET: Admin/News
        public ActionResult Index()
        {
           
            return View(newsRepository.GetAllNewsREpository());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = newsRepository.GetNewsById(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(newsGroupRepository.GetAllNewsGroups(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,GroupId,NewsTitle,ShortDescribtion,NewsText,visited,ImageName,ShoWInslider,CreateDate")] News news,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                news.CreateDate = DateTime.Now;
                news.visited = 0;
                if(imgUp != null)
                {
                    news.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/NewsImages" + news.ImageName));
                }
                newsRepository.insertNews(news);
                newsRepository.save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(newsGroupRepository.GetAllNewsGroups(), "GroupId", "GroupTitle", news.GroupId);
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = newsRepository.GetNewsById(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(newsGroupRepository.GetAllNewsGroups(), "GroupId", "GroupTitle", news.GroupId);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,GroupId,NewsTitle,ShortDescribtion,NewsText,visited,ImageName,ShoWInslider,CreateDate")] News news)
        {
            if (ModelState.IsValid)
            {
                newsRepository.updateNews(news);
                newsRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(newsGroupRepository.GetAllNewsGroups(), "GroupId", "GroupTitle", news.GroupId);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = newsRepository.GetNewsById(id.Value);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            newsRepository.DeleteNews(id);
            newsRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                newsRepository.Dispose();
                newsGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
