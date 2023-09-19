using Car_Data;
using Car_Rental.Data.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using System.Collections.Generic;

namespace Car_Business.Classes
{
    public class BookingProcessor
    {
        public readonly VehicleTypes VehicleType;


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

        public Car CreateCar(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available)
        {
            Car newVehicle = new Car(costDay, costKM, odometer,  regNo, make, available);

            return newVehicle;
        }

        public List<VehicleTypes> GetEnums<T>(T item) 
        {

            _db.Add(item);

            return _db._vehicleTypes;
        }
      


        public void AddCustomer<T>(T item)
        {

            _db.Add(item);

        }
        public void AddVehicle<T>(T item)
        {
            _db.Add(item);
        }
      

        public List<IPerson> GetPersons()
        {
            return _db._persons; 
        }
        
  

    }
}
