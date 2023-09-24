using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TQ1Class
    {
        NORTHWNDEntities q1 = new NORTHWNDEntities();
        public List<TableQuery1> GetQUERY1()
        {
         
            return q1.SearchQuery1().ToList();
        }
    }
}