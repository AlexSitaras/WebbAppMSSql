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
    public class TableQuery5Controller : Controller
    {
        
        private NORTHWNDEntities db = new NORTHWNDEntities();
        TQ5Class mod5 = new TQ5Class();
        // GET: TableQuery5
        public ActionResult Index(String search1, String search2 ,String ye)
        {
            var query5 = from q in mod5.GetQUERY5()
                         select q;

            if (!(String.IsNullOrEmpty(ye)))
            {
                Int32 d = Convert.ToInt32(ye);

                query5 = query5.Where(x => x.Year.Equals(d));
                 

                if (!(String.IsNullOrEmpty(ye)))
                {

                    query5 = query5.Where(x => x.ProductName.StartsWith(search1)).Where(m => m.ProductName.EndsWith(search2));

                }
                else
                {
                    query5 = query5;
                }
            }
            else if ((String.IsNullOrEmpty(ye)))
            {
                

                if (!(String.IsNullOrEmpty(search1)) && !(String.IsNullOrEmpty(search2)))
                {
                    query5 = query5.Where(x => x.ProductName.StartsWith(search1)).Where(m => m.ProductName.EndsWith(search2));
                }
                else
                {
                    query5 = query5;
                }

            }

            return View(query5.ToList());
        }

        // GET: TableQuery5/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery5 tableQuery5 = db.TableQuery5.Find(id);
            if (tableQuery5 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery5);
        }

        // GET: TableQuery5/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableQuery5/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName,CompanyName,Year,Trimester,Total_Quantity")] TableQuery5 tableQuery5)
        {
            if (ModelState.IsValid)
            {
                db.TableQuery5.Add(tableQuery5);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableQuery5);
        }

        // GET: TableQuery5/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery5 tableQuery5 = db.TableQuery5.Find(id);
            if (tableQuery5 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery5);
        }

        // POST: TableQuery5/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductName,CompanyName,Year,Trimester,Total_Quantity")] TableQuery5 tableQuery5)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableQuery5).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableQuery5);
        }

        // GET: TableQuery5/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery5 tableQuery5 = db.TableQuery5.Find(id);
            if (tableQuery5 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery5);
        }

        // POST: TableQuery5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TableQuery5 tableQuery5 = db.TableQuery5.Find(id);
            db.TableQuery5.Remove(tableQuery5);
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
