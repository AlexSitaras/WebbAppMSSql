using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TQ3Class
    {
        NORTHWNDEntities q3 = new NORTHWNDEntities();
        public List<TableQuery3> GetQUERY3()
        {

            return q3.SearchQuery3().ToList();
        }
    }
}