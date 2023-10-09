using Car_Data;
using Car_Rental.Data.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using System.Collections.Generic;
using System.Linq.Expressions;

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
            int newId = (_db.Get<IPerson>().Any() ? _db.Get<IPerson>().Max(p => p.CustomerId) + 1 : 1);


            Customer newCustomer = new Customer(lName, fName, SSN, newId);
            

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

        public Booking CreateBooking(IPerson customer, IVehicle vehicle)
        {
            Booking newBooking = new Booking(vehicle, customer);
            newBooking.BookingId = _db.Get<IBooking>().Count() == 0 ? 1 : _db.Get<IBooking>().Count() + 1;
            return newBooking;


        }

        public void ReturnVehicle(string vehicle, int? odometerReturn)
        {
            var cancelBooking = _db.Get<IBooking>().Single(a => a.Vehicle.regNo == vehicle);

            cancelBooking.TotalCost = cancelBooking.Vehicle.costKM * (odometerReturn - cancelBooking.Vehicle.odometer) + cancelBooking.Vehicle.costDay;
            cancelBooking.Status = true;
            cancelBooking.Vehicle.available = true;
            cancelBooking.BookingReturned = DateTime.Now;
            cancelBooking.KMReturned = odometerReturn;

            var car = _db.Get<IVehicle>().Single(a => a.regNo == vehicle);
            car.odometer = odometerReturn;
            



        }
      

        public void AddCustomer<T>(T item) where T : IPerson
        {

            _db.Add<IPerson>(item);

        }
        public void AddVehicle<T>(T item) where T : IVehicle
        {
            _db.Add<IVehicle>(item);
        }

        public void AddBooking<T>(T item) where T : IBooking
        {
            _db.Add<IBooking>(item);
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

        public List<IVehicle> GetVehicles(Expression<Func<IVehicle, bool>>? expression = null) 
        { 
            return _db.Get<IVehicle>(expression);
        }

        public List<IVehicle> GetFilteredVehicles(int costDayFilter, int odometerFilter)
        {
            return _db.Get<IVehicle>(v => v.costDay <= costDayFilter && v.odometer <= odometerFilter);

        }

        public List<VehicleTypes> GetVehicleTypes()
        {

            return _db.Get<VehicleTypes>().ToList();    
        }


    }
}
