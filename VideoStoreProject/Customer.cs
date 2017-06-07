using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStoreProject
{
    public class Customer
    {
        public string Name { get; set; }
        public string SSn { get; set; }

        public Customer(string name, string ssn)
        {
            this.Name = name;
            this.SSn = ssn;
        }

        public Customer()
        {
            
        }
    }
}
