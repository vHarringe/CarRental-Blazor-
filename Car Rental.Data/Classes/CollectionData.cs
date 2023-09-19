using Car_Data;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        public List<IPerson> _persons { get; } = new List<IPerson>();

        public List<IBooking> _bookings { get; } = new List<IBooking>();
        public List<IVehicle> _vehicles { get; }  = new List<IVehicle>();

        public void SeedData()
        {
            Customer customer1 = new Customer("Svensson", "Bosse", 1811);
            customer1.customerId = "#1";
            Customer customer2 = new Customer("Granqvist", "Pelle", 5152);
            customer2.customerId = "#2";
            Customer customer3 = new Customer("Marklund", "Maria", 7615);
            customer3.customerId = "#3";

            _persons.Add(customer1);
            _persons.Add(customer2);
            _persons.Add(customer3);

            Car car1 = new Car(200, 15, 4500, "KYP404", "Renault", false);
            Car car2 = new Car(300, 10, 15500, "ARL999", "Kia", true);
            Car car3 = new Car(3500, 300, 2200, "GAP613", "Ferrari", true);

            Motorcycle m1 = new Motorcycle(450, 20, 1500, "JUS666", "Yamaha", true);
            
            _vehicles.Add(m1);
            _vehicles.Add(car1);
            _vehicles.Add(car2);
            _vehicles.Add(car3);
        }


        public List<VehicleTypes> _vehicleTypes { get; } = new List<VehicleTypes> 
        { 
            VehicleTypes.Sedan,
            VehicleTypes.Combi,
            VehicleTypes.Van,
            VehicleTypes.Motorcycle 
        };

        
        
        public void Get<T>(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
          

        }


	    public void Add<T>(T item)
        {
            if(item == null) throw new ArgumentNullException("item");
            else if(item is IPerson person)
            {
                _persons.Add(person);
            }
            else if(item is IVehicle vehicle)
            {
                _vehicles.Add(vehicle);
            }
            




        }

        public void AddCustomer(string lName, string fName, int SSN) { }

        
    }
}
