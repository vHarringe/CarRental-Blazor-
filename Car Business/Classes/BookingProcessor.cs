using Car_Data;
using Car_Rental.Data.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;


namespace Car_Business.Classes
{
    public class BookingProcessor
    {
        public readonly IData _db;
        

        public BookingProcessor(IData db)
        {
            _db = db;
            
        }






        public void AddCustomer(string lName, string fName, int SSN)
        {
            var newCustomer = new Customer
            {
                lastName = lName,
                firstName = fName,
                Ssn = SSN,
                customerId = _db._persons.Count() + 1
            };

            _db._persons.Add(newCustomer); 
        }

        public List<IPerson> GetPersons()
        {
            return _db._persons; 
        }
        
  

    }
}
