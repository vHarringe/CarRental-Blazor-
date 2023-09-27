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
            newCustomer.CustomerId = (_db.Get<IPerson>().Count() + 1);

            return newCustomer;

        }

        public Car CreateCar(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available, VehicleTypes? vehicleType)
        {
            Car newVehicle = new Car(costDay, costKM, odometer,  regNo, make, available, vehicleType);

            return newVehicle;
        }

        public Motorcycle CreateMotorcycle(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available, VehicleTypes? vehicleType)
        {

            Motorcycle newMotorcycle = new(costDay, costKM,odometer,regNo,make,available,vehicleType);
            return newMotorcycle;


        }

        public Booking CreateBooking(int? customer, IVehicle vehicle)
        {
            Booking newBooking = new Booking(customer, vehicle);
            newBooking.BookingId = _db.Get<IBooking>().Count() + 1;
            return newBooking;


        }


      

        public void AddCustomer<T>(T item)
        {

            _db.Add(item);

        }
        public void AddVehicle<T>(T item)
        {
            _db.Add(item);
        }

        public void AddBooking<T>(T item)
        {
            _db.Add(item);
        }

        /*
        public List<IPerson> GetPersons()
        {
            return _db._persons; 
        }
        */

        public List<IBooking> GetBookings()
        {
            return _db.Get<IBooking>().ToList();

        }

        public List<IPerson> GetPersons()
        {
           
            return _db.Get<IPerson>().ToList();
        }

        public List<IVehicle> GetVehicles() 
        { 
            return _db.Get<IVehicle>().ToList();
        
        }
        
        public List<VehicleTypes> GetVehicleTypes()
        {

            return _db.Get<VehicleTypes>().ToList();    
        }


    }
}
