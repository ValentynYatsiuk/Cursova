using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingsForAllDay.Models;

namespace TrainingsForAllDay.Controllers
{
    public class WednesdaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wednesdays
        public ActionResult Index()
        {
            var wednesdays = db.Wednesdays.Include(w => w.Date);
            return View(wednesdays.ToList());
        }

        // GET: Wednesdays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wednesday wednesday = db.Wednesdays.Find(id);
            if (wednesday == null)
            {
                return HttpNotFound();
            }
            return View(wednesday);
        }

        // GET: Wednesdays/Create
        public ActionResult Create()
        {
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId");
            return View();
        }

        // POST: Wednesdays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WednesdayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Wednesday wednesday)
        {
            if (ModelState.IsValid)
            {
                db.Wednesdays.Add(wednesday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", wednesday.DateDateId);
            return View(wednesday);
        }

        // GET: Wednesdays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wednesday wednesday = db.Wednesdays.Find(id);
            if (wednesday == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", wednesday.DateDateId);
            return View(wednesday);
        }

        // POST: Wednesdays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WednesdayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Wednesday wednesday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wednesday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", wednesday.DateDateId);
            return View(wednesday);
        }

        // GET: Wednesdays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wednesday wednesday = db.Wednesdays.Find(id);
            if (wednesday == null)
            {
                return HttpNotFound();
            }
            return View(wednesday);
        }

        // POST: Wednesdays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wednesday wednesday = db.Wednesdays.Find(id);
            db.Wednesdays.Remove(wednesday);
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
