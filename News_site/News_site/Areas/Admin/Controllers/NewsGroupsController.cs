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
        INewsGroupRepository newsGroupRepository;
        public NewsGroupsController()
        {
            newsGroupRepository = new NewsGroupRepository();
        }

        // GET: Admin/NewsGroups
        public ActionResult Index()
        {
            return View(newsGroupRepository.GetAllNewsGroups());
        }

        // GET: Admin/NewsGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsGroups newsGroups = newsGroupRepository.GetNewsById(id.Value);
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
                newsGroupRepository.insertNewsGroup(newsGroups);
                newsGroupRepository.save();
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
            NewsGroups newsGroups = newsGroupRepository.GetNewsById(id.Value);
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
                newsGroupRepository.updateNewsGroup(newsGroups);
                newsGroupRepository.save();
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
            NewsGroups newsGroups = newsGroupRepository.GetNewsById(id.Value);
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

            newsGroupRepository.DeleteNewsGroup(id);
            newsGroupRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                newsGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
