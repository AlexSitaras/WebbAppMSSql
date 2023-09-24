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
    public class TableQuery4Controller : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();
        TQ4Class mod4 = new TQ4Class();
        // GET: TableQuery4
        public ActionResult Index(String search1, String search2, String t, String date)
        {
           
            var query4 = from q in mod4.GetQUERY4()
                         select q;
            

            if (!(String.IsNullOrEmpty(t)))
            {
                Int32 z = Convert.ToInt32(t);

                if (!(String.IsNullOrEmpty(search1)) && !(String.IsNullOrEmpty(search2)))
                {

                    query4 = query4.Where(x => x.FirstName.StartsWith(search1)).Where(m => m.FirstName.EndsWith(search2)).Take(z);


                    if (!(String.IsNullOrEmpty(date)))
                    {

                        query4 = query4.Where(x => Convert.ToString(x.OrderDate).StartsWith(date)).Take(z);
                    }
                    else
                    {
                        query4 = query4.Take(z);
                    }
                }
                else if ((String.IsNullOrEmpty(search1)) && (String.IsNullOrEmpty(search2)))
                {
                    if (!(String.IsNullOrEmpty(date)))
                    {
                        query4 = query4.Where(x => Convert.ToString(x.OrderDate).StartsWith(date)).Take(z);
                    }
                    else
                    {
                        query4 = query4.Take(z);
                    }

                }
            }
            else
            {
                if (!(String.IsNullOrEmpty(search1)) && !(String.IsNullOrEmpty(search2)))
                {

                    query4 = query4.Where(x => x.FirstName.StartsWith(search1)).Where(m => m.FirstName.EndsWith(search2));


                    if (!(String.IsNullOrEmpty(date)))
                    {
                        
                        query4 = query4.Where(x => Convert.ToString(x.OrderDate).StartsWith(date));
                    }
                    else
                    {
                        query4 = query4;
                    }
                }
                else if ((String.IsNullOrEmpty(search1)) && (String.IsNullOrEmpty(search2)))
                {
                    if (!(String.IsNullOrEmpty(date)))
                    {
                        query4 = query4.Where(x => Convert.ToString(x.OrderDate).StartsWith(date));
                    }
                    else
                    {
                        query4 = query4;
                    }

                }
            }


            return View(query4.ToList().OrderBy(v =>v.TOTAL_MONEY));

        }

        // GET: TableQuery4/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery4 tableQuery4 = db.TableQuery4.Find(id);
            if (tableQuery4 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery4);
        }

        // GET: TableQuery4/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableQuery4/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TOTAL_MONEY,EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,Address,City,Region,PostalCode,Country,HomePhone,Extension,OrderDate")] TableQuery4 tableQuery4)
        {
            if (ModelState.IsValid)
            {
                db.TableQuery4.Add(tableQuery4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableQuery4);
        }

        // GET: TableQuery4/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery4 tableQuery4 = db.TableQuery4.Find(id);
            if (tableQuery4 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery4);
        }

        // POST: TableQuery4/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TOTAL_MONEY,EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,Address,City,Region,PostalCode,Country,HomePhone,Extension,OrderDate")] TableQuery4 tableQuery4)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableQuery4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableQuery4);
        }

        // GET: TableQuery4/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableQuery4 tableQuery4 = db.TableQuery4.Find(id);
            if (tableQuery4 == null)
            {
                return HttpNotFound();
            }
            return View(tableQuery4);
        }

        // POST: TableQuery4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TableQuery4 tableQuery4 = db.TableQuery4.Find(id);
            db.TableQuery4.Remove(tableQuery4);
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
