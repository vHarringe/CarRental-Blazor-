using Car_Data;
using Car_Rental.Data.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using System.Collections.Generic;
using System.Linq.Expressions;
using Car_Rental.Common.Extensions;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace Car_Business.Classes
{
    public class BookingProcessor
    {
        public readonly VehicleTypes VehicleType;


        public readonly IData _db;
        public readonly Input _input;
        

        public BookingProcessor(IData db, Input i)
        {
            _db = db;
            _input = i;
        }
        

        public void CreateCustomer()
        {
            if (_input.lName is not null &&
                _input.fName is not null &&
                _input.Ssn is not null)
            {
                int newId = (_db.Get<IPerson>().Any() ? _db.Get<IPerson>().Max(p => p.CustomerId) + 1 : 1);
                Customer newCustomer = new(_input.lName, _input.fName, _input.Ssn, newId);

                AddCustomer(newCustomer);
                _input.lName = "";
                _input.fName = "";
                _input.Ssn = null;
                _input.alertCustomer = false;
               
            }
            else
            {
                _input.alertCustomer = true;
            }


        }

        public void CreateVehicle()
        {
            
            _input.alert = false;
            if (_input.costDay != null &&
                _input.costKM != null &&
                _input.odometer != null &&
                _input.regNo != null &&
                _input.make != null &&
                _input.vehicleType != null)
            {


                    if (_input.vehicleType == VehicleTypes.Sedan || _input.vehicleType == VehicleTypes.Van || _input.vehicleType == VehicleTypes.Combi)
                    {

                        AddVehicle(CreateCar(_input.costDay, _input.costKM, _input.odometer, _input.regNo, _input.make, true, _input.vehicleType));

                        _input.costDay = null;
                        _input.costKM = null;
                        _input.odometer = null;
                        _input.regNo = null;
                        _input.make = null;
                        _input.vehicleType = null;


                    }
                    else if (_input.vehicleType == VehicleTypes.Motorcycle)
                    {
                        AddVehicle(CreateMotorcycle(_input.costDay, _input.costKM, _input.odometer, _input.regNo, _input.make, true, _input.vehicleType));
                        _input.costDay = null;
                        _input.costKM = null;
                        _input.odometer = null;
                        _input.regNo = null;
                        _input.make = null;
                        _input.vehicleType = null;

                    }


            }
            else
            {
                _input.costDay = null;
                _input.costKM = null;
                _input.odometer = null;
                _input.regNo = null;
                _input.make = null;
                _input.vehicleType = null;
                _input.alert = true;

            }


        }

        
        public void GetFilterValues()
        {
            var max = GetVehicles().OrderByDescending(c => c.costDay).FirstOrDefault();
            _input.maxCost = max != null ? Convert.ToInt32(max.costDay) : 100;
            var min = GetVehicles().OrderBy(c => c.costDay).FirstOrDefault();
            _input.minCost = min != null ? Convert.ToInt32(min.costDay) : 0;

            _input.costDayFilter = _input.maxCost;

            var maxOdo = GetVehicles().OrderByDescending(o => o.odometer).FirstOrDefault();
            _input.maxOdometer = maxOdo != null ? Convert.ToInt32(maxOdo.odometer) : 100;
            var minOdo = GetVehicles().OrderBy(o => o.odometer).FirstOrDefault();
            _input.minOdometer = minOdo != null ? Convert.ToInt32(minOdo.odometer) : 100;

            _input.odometerFilter = _input.maxOdometer;

        }

        public async Task SubmitBookingAsync(int? customerId, IVehicle car)
        {
            if (customerId is null)
            {
                car.RedFlagReturn = true;
                return;
            }
            _input.isDisabled = true;

            var bookingCustomer = GetCustomer(customerId);

            var booking = await CreateBookingAsync(bookingCustomer, car);

            AddBooking(booking);

            car.available = false;

            _input.isDisabled = false;


        }

        public static Car CreateCar(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available, VehicleTypes? vehicleType)
        {
            Car newVehicle = new(costDay, costKM, odometer,  regNo, make, available, vehicleType);

            return newVehicle;
        }

        public static Motorcycle CreateMotorcycle(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available, VehicleTypes? vehicleType)
        {

            Motorcycle newMotorcycle = new(costDay, costKM,odometer,regNo,make,available,vehicleType);
            return newMotorcycle;


        }

        public async Task<Booking> CreateBookingAsync(IPerson customer, IVehicle vehicle)
        {
            await Task.Delay(2000);
            Booking newBooking = new(vehicle, customer)
            {
                BookingId = _db.Get<IBooking>().Count == 0 ? 1 : _db.Get<IBooking>().Count + 1
            };
            

            return newBooking;

        }
       


        public void ReturnVehicle(string vehicle, int? odometerReturn)
        {
            Vehicle car1 = GetVehicle(vehicle);
            if (odometerReturn > car1.odometer && odometerReturn is not null)
            {
                var cancelBooking = _db.Get<IBooking>().Last(a => a.Vehicle.regNo == vehicle);


                cancelBooking.KMReturned = odometerReturn;
                cancelBooking.BookingReturned = DateTime.Now;

                cancelBooking.CalcPrice(); // extensionmetod sätter värde på totalCost

                cancelBooking.Status = true;
                cancelBooking.Vehicle.available = true;

                var car = _db.Get<IVehicle>().Single(a => a.regNo == vehicle);
                car.SelectedCustomerId = null;
                car.odometer = odometerReturn;
            }
            else
            {
                car1.RedFlagReturn = true;
            }

            car1.OdometerReturned = null;
            var maxOdo = GetVehicles().OrderByDescending(o => o.odometer).FirstOrDefault();
            _input.maxOdometer = maxOdo != null ? Convert.ToInt32(maxOdo.odometer) : 100;

            _input.odometerFilter = _input.maxOdometer;

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

        public Customer GetCustomer(int? customerId)
        {
            return (Customer)_db.GetSingle<IPerson>(a => a.CustomerId == customerId);
        }

        public Vehicle GetVehicle(string reg)
        {
            return (Vehicle)_db.GetSingle<IVehicle>(a => a.regNo == reg);
        }




    }
}
