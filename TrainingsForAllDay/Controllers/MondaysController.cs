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
    public class MondaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mondays
        public ViewResult Index()
        {
           // var mondays = db.Mondays.Include(m => m.Date);
            return View(db.Mondays.ToList());
        }

        // GET: Mondays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monday monday = db.Mondays.Find(id);
            if (monday == null)
            {
                return HttpNotFound();
            }
            return View(monday);
        }

        // GET: Mondays/Create
        public ActionResult Create()
        {
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId");
            return View();
        }

        // POST: Mondays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MondayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Monday monday)
        {
            if (ModelState.IsValid)
            {
                db.Mondays.Add(monday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", monday.DateDateId);
            return View(monday);
        }

        // GET: Mondays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monday monday = db.Mondays.Find(id);
            if (monday == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", monday.DateDateId);
            return View(monday);
        }

        // POST: Mondays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MondayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Monday monday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", monday.DateDateId);
            return View(monday);
        }

        // GET: Mondays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monday monday = db.Mondays.Find(id);
            if (monday == null)
            {
                return HttpNotFound();
            }
            return View(monday);
        }

        // POST: Mondays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monday monday = db.Mondays.Find(id);
            db.Mondays.Remove(monday);
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
