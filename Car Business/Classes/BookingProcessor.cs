using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;

namespace Car_Business.Classes
{
    internal class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db) => _db = db;

        public void AddPerson(IPerson customer)
        {
            
            var person = new Customer
            {
                
                lastName = "Vilgot Harringe",
                firstName = "vilgot@example.com",
                Ssn = 12323
            };

            
           
        }
    }
}