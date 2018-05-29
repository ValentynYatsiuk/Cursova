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
    public class FridaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fridays
        public ActionResult Index()
        {
            var fridays = db.Fridays.Include(f => f.Date);
            return View(fridays.ToList());
        }

        // GET: Fridays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friday friday = db.Fridays.Find(id);
            if (friday == null)
            {
                return HttpNotFound();
            }
            return View(friday);
        }

        // GET: Fridays/Create
        public ActionResult Create()
        {
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId");
            return View();
        }

        // POST: Fridays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FridayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Friday friday)
        {
            if (ModelState.IsValid)
            {
                db.Fridays.Add(friday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", friday.DateDateId);
            return View(friday);
        }

        // GET: Fridays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friday friday = db.Fridays.Find(id);
            if (friday == null)
            {
                return HttpNotFound();
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", friday.DateDateId);
            return View(friday);
        }

        // POST: Fridays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FridayId,NameOfTraining,WeightOfTraining,Approach,Appr1,Appr2,Appr3,Appr4,Appr5,DateDateId")] Friday friday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DateDateId = new SelectList(db.Dates, "DateId", "DateId", friday.DateDateId);
            return View(friday);
        }

        // GET: Fridays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friday friday = db.Fridays.Find(id);
            if (friday == null)
            {
                return HttpNotFound();
            }
            return View(friday);
        }

        // POST: Fridays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friday friday = db.Fridays.Find(id);
            db.Fridays.Remove(friday);
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
