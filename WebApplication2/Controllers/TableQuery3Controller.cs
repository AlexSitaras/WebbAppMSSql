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
    public class TableQuery3Controller : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();
        TQ3Class mod3 = new TQ3Class();
        // GET: TableQuery3
        public ActionResult Index(String search1, String search2, String d, String e)
        {
          
            var query3 = from q in mod3.GetQUERY3()
                         select q;

            if (!(String.IsNullOrEmpty(search1)) && !(String.IsNullOrEmpty(search2)))
            {

                query3 = query3.Where(x => x.CompanyName.StartsWith(search1)).Where(m => m.CompanyName.EndsWith(search2));


                if ((String.IsNullOrEmpty(e)) && (String.IsNullOrEmpty(d)))
                {

                    query3 = query3;
                }
                else if (!(String.IsNullOrEmpty(d)) && !(String.IsNullOrEmpty(e)))
                {
                    DateTime da = Convert.ToDateTime(d);
                    DateTime eda = Convert.ToDateTime(e);
                    query3 = query3.Where(q => q.OrderDate > da).Where(q => q.OrderDate < eda);
                }
            }
            else if ((String.IsNullOrEmpty(search1)) && (String.IsNullOrEmpty(search2)))
            {
                if (!(String.IsNullOrEmpty(d)) && !(String.IsNullOrEmpty(e)))
                {
                    DateTime da = Convert.ToDateTime(d);
                    DateTime eda = Convert.ToDateTime(e);
                    query3 = query3.Where(q => q.OrderDate > da).Where(q => q.OrderDate < eda);
                }
                else
                {
                    query3 = query3;
                }

            }


            return View(query3.ToList());

        }


            // GET: TableQuery3/Details/5
            public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery3 tableQuery3 = db.TableQuery3.Find(id);
            if (tableQuery3 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery3);
        }

        // GET: TableQuery3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableQuery3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,CompanyName,OrderID,OrderDate")] TableQuery3 tableQuery3)
        {
            if (ModelState.IsValid)
            {
                db.TableQuery3.Add(tableQuery3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableQuery3);
        }

        // GET: TableQuery3/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery3 tableQuery3 = db.TableQuery3.Find(id);
            if (tableQuery3 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery3);
        }

        // POST: TableQuery3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,CompanyName,OrderID,OrderDate")] TableQuery3 tableQuery3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableQuery3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableQuery3);
        }

        // GET: TableQuery3/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery3 tableQuery3 = db.TableQuery3.Find(id);
            if (tableQuery3 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery3);
        }

        // POST: TableQuery3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TableQuery3 tableQuery3 = db.TableQuery3.Find(id);
            db.TableQuery3.Remove(tableQuery3);
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
