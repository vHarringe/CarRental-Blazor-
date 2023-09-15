using Car_Data;
using Car_Rental.Data.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;


namespace Car_Business.Classes
{
    public class BookingProcessor
    {
        public readonly IData _db;
        

        public BookingProcessor(IData db)
        {
            _db = db;
            
        }

        public Customer CreateCustomer(string lName, string fName, int? SSN)
        {
           Customer newCustomer = new Customer(lName, fName, SSN);
            newCustomer.customerId = $"#{(_db._persons.Count() + 1)}";

            return newCustomer;

        }

        public void CreateVehicle()
        {


        }
      


        public void AddCustomer<T>(T item)
        {

            _db.Add(item);

        }
      

        public List<IPerson> GetPersons()
        {
            return _db._persons; 
        }
        
  

    }
}
