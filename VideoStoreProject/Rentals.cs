using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStoreProject
{
    public class Rentals
    {
        public string Title { get; set; }
        public string SecurityNumber { get; set; }
        public DateTime DateTime { get; set; }



        public Rentals(string title, string ssn, DateTime datetime)
        {
            Title = title;
            SecurityNumber = ssn;
            DateTime = datetime;
        }
        public Rentals(string title, string ssn)
        {
            Title = title;
            SecurityNumber = ssn;
        }
        public Rentals()
        {

        }
    }
}
