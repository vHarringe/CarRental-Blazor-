using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IBooking> _bookings = new List<IBooking>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();

      
        public void AddCustomer(string lName, string fName, int SSN)
        {
            var newCustomer = new Customer
            {
                lastName = lName,
                firstName = fName,
                Ssn = SSN

            };

            _persons.Add(newCustomer);

        }

        public IEnumerable<IPerson> GetPersons()
        {
            return _persons;
        }

        public void AddCustomer(IPerson customer)
        {
            _persons.Add(customer);
        }





    }
}
