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
    public class TableQuery1Controller : Controller
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();
        TQ1Class mod = new TQ1Class();
        // GET: TableQuery1
        public ActionResult Index(string d , string e, string t)
        {
            
            var query1 = from q in mod.GetQUERY1()
                         select q;

            if (!(String.IsNullOrEmpty(d)) && !(String.IsNullOrEmpty(e)))
            {
                DateTime da = Convert.ToDateTime(d);
                DateTime eda = Convert.ToDateTime(e);
                query1 = query1.Where(x => x.OrderDate > da).Where(y => y.OrderDate < eda);

              
            }
            if (!(String.IsNullOrEmpty(t)))
            {
                Int32 z = Convert.ToInt32(t);
                query1 = query1.Take(z);
            }
            return View(query1.OrderBy(w => w.TOTAL));
        }

      
    }
}
