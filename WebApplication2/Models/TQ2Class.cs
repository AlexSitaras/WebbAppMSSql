using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TQ2Class
    {
        NORTHWNDEntities q2 = new NORTHWNDEntities();
        public List<TableQuery2> GetQUERY2()
        {

            return q2.SearchQuery2().ToList();
        }
    }
}