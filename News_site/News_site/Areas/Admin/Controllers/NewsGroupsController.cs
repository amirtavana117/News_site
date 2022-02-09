using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace News_site.Areas.Admin.Controllers
{
    public class NewsGroupsController : Controller
    {
        private NewsContext db = new NewsContext();

        // GET: Admin/NewsGroups
        public ActionResult Index()
        {
            return View(db.newsGroups.ToList());
        }

        // GET: Admin/NewsGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroups newsGroups = db.newsGroups.Find(id);
            if (newsGroups == null)
            {
                return HttpNotFound();
            }
            return View(newsGroups);
        }

        // GET: Admin/NewsGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NewsGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle")] NewsGroups newsGroups)
        {
            if (ModelState.IsValid)
            {
                db.newsGroups.Add(newsGroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsGroups);
        }

        // GET: Admin/NewsGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroups newsGroups = db.newsGroups.Find(id);
            if (newsGroups == null)
            {
                return HttpNotFound();
            }
            return View(newsGroups);
        }

        // POST: Admin/NewsGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle")] NewsGroups newsGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsGroups);
        }

        // GET: Admin/NewsGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroups newsGroups = db.newsGroups.Find(id);
            if (newsGroups == null)
            {
                return HttpNotFound();
            }
            return View(newsGroups);
        }

        // POST: Admin/NewsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsGroups newsGroups = db.newsGroups.Find(id);
            db.newsGroups.Remove(newsGroups);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
