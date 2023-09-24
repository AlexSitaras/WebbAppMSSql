using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TQ5Class
    {
        NORTHWNDEntities q5 = new NORTHWNDEntities();
        public List<TableQuery5> GetQUERY5()
        {

            return q5.SearchQuery5().ToList();
        }
    }
}