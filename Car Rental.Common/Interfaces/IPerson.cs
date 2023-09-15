using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IPerson
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int Ssn { get; set; }
        
        public string customerId { get; set; }



    }
}
