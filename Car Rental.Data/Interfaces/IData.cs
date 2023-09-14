using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Interfaces;

namespace Car_Data
{
    public interface IData
    {
        List<IPerson> _persons { get; }
        void AddCustomer(string lName, string fName, int SSN);
        public IEnumerable<T> Get<T>(Func<T, bool> filter = null);


    }
}
