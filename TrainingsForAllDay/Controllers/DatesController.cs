﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using TrainingsForAllDay.Models;



namespace TrainingsForAllDay.Controllers
{
    public class DatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dates
        public ViewResult Index()
        {
            return View(db.Dates.ToList());
        }

        // GET: Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);          
        }

        // GET: Dates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateId,Datetime")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(date);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(date);
        }

        // GET: Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateId,Datetime")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(date);
        }

        // GET: Dates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Date date = db.Dates.Find(id);
            db.Dates.Remove(date);
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
