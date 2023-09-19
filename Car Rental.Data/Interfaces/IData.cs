using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Data
{
    public interface IData
    {
        List<IPerson> _persons { get; }
        List<IVehicle> _vehicles { get; }
        List<IBooking> _bookings { get; }

        List<VehicleTypes> _vehicleTypes { get; }

        void AddCustomer(string lName, string fName, int SSN);

        public void Add<T>(T item);

        public void Get<T>(T item);

        void SeedData();














   


    }
}
