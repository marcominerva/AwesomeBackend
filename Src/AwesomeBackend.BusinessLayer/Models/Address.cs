using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.BusinessLayer.Models
{
    public class Address
    {
        public string PostalCode { get; set; }

        public string Street { get; set; }

        public string Location { get; set; }

        public string Province { get; set; }
    }
}
