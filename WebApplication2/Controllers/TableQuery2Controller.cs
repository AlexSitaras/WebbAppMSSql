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
    public class TableQuery2Controller : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();
        TQ2Class mod2 = new TQ2Class();
        // GET: TableQuery2
        public ActionResult Index(string d, string e ,string n1 , string n2)
        {
            
            var query2 = from q in mod2.GetQUERY2()
                         select q;

            if (!(String.IsNullOrEmpty(d)) && !(String.IsNullOrEmpty(e)))
            {
                DateTime da = Convert.ToDateTime(d);
                DateTime eda = Convert.ToDateTime(e);
                query2 = query2.Where(a => a.OrderDate > da).Where(s => s.OrderDate < eda);
            }
            if ( !(String.IsNullOrEmpty(n1)) && !(String.IsNullOrEmpty(n2)) )
            {
                query2 = query2.Where(x => x.ContactName.StartsWith(n1)).Where(y =>y.ContactName.EndsWith(n2));
            }
            return View(query2.OrderBy(r => r.TOTAL_MONEY));
        }

        // GET: TableQuery2/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery2 tableQuery2 = db.TableQuery2.Find(id);
            if (tableQuery2 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery2);
        }

        // GET: TableQuery2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableQuery2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TOTAL_MONEY,CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,OrderDate")] TableQuery2 tableQuery2)
        {
            if (ModelState.IsValid)
            {
                db.TableQuery2.Add(tableQuery2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableQuery2);
        }

        // GET: TableQuery2/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery2 tableQuery2 = db.TableQuery2.Find(id);
            if (tableQuery2 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery2);
        }

        // POST: TableQuery2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TOTAL_MONEY,CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,OrderDate")] TableQuery2 tableQuery2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableQuery2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableQuery2);
        }

        // GET: TableQuery2/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery2 tableQuery2 = db.TableQuery2.Find(id);
            if (tableQuery2 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery2);
        }

        // POST: TableQuery2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TableQuery2 tableQuery2 = db.TableQuery2.Find(id);
            db.TableQuery2.Remove(tableQuery2);
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
