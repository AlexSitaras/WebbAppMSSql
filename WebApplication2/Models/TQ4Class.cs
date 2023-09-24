using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TQ4Class
    {
        NORTHWNDEntities q4 = new NORTHWNDEntities();
        public List<TableQuery4> GetQUERY4() 
        {
           
            return q4.SearchQuery4().ToList();
        }
    }
}