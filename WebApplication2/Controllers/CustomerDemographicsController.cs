using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerDemographicsController : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        // GET: CustomerDemographics
        public ActionResult Index()
        {
            return View(db.CustomerDemographics.ToList());
        }

        // GET: CustomerDemographics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = db.CustomerDemographics.Find(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDemographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerTypeID,CustomerDesc")] CustomerDemographic customerDemographic)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDemographics.Add(customerDemographic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = db.CustomerDemographics.Find(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // POST: CustomerDemographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerTypeID,CustomerDesc")] CustomerDemographic customerDemographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDemographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = db.CustomerDemographics.Find(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // POST: CustomerDemographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomerDemographic customerDemographic = db.CustomerDemographics.Find(id);
            db.CustomerDemographics.Remove(customerDemographic);
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
