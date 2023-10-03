using Car_Data;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        List<IPerson> _persons { get; } = new List<IPerson>(); 

        List<IBooking> _bookings { get; } = new List<IBooking>();
        List<IVehicle> _vehicles { get; }  = new List<IVehicle>();

        public void SeedData()
        {
            Customer customer1 = new Customer("Svensson", "Bosse", 1811);
            customer1.CustomerId = 1;
            Customer customer2 = new Customer("Pettersson", "Pelle", 5152);
            customer2.CustomerId = 2;
            Customer customer3 = new Customer("Mört", "Maria", 7615);
            customer3.CustomerId = 3;

            _persons.Add(customer1);
            _persons.Add(customer2);
            _persons.Add(customer3);

            Car car1 = new Car(200, 15, 4500, "KYP404", "Renault", false, VehicleTypes.Sedan);
            Car car2 = new Car(1000, 10, 15500, "ARL999", "Kia", true, VehicleTypes.Van);
            Car car3 = new Car(2500, 300, 2200, "GAP613", "Ferrari", true, VehicleTypes.Combi);

            Motorcycle m1 = new Motorcycle(450, 20, 1500, "JUS666", "Yamaha", true, VehicleTypes.Motorcycle);
            
            _vehicles.Add(m1);
            _vehicles.Add(car1);
            _vehicles.Add(car2);
            _vehicles.Add(car3);
        }


        private List<VehicleTypes> _vehicleTypes { get; } = new List<VehicleTypes> 
        { 
            VehicleTypes.Sedan,
            VehicleTypes.Combi,
            VehicleTypes.Van,
            VehicleTypes.Motorcycle 
        };



        public List<T> Get<T>(Expression<Func<T, bool>>? expression = null)
        {

            if (typeof(T) == typeof(IPerson))
            {
                if (expression != null)
                {
                    var filter = expression.Compile();
                    return _persons.Cast<T>().Where(filter).ToList();
                }
                return _persons.Cast<T>().ToList();
            }

            else if (typeof(T) == typeof(IVehicle))
            {
                if(expression != null)
                {
                    var filter = expression.Compile();
                    return _vehicles.Cast<T>().Where(filter).ToList();
                }
                else
                {
                    return _vehicles.Cast<T>().ToList();
                }
                
                
            }
               

            else if (typeof(T) == typeof(IBooking))
                return _bookings.Cast<T>().ToList();

            else if (typeof(T) == typeof(VehicleTypes))
                return _vehicleTypes.Cast<T>().ToList();

            throw new Exception("");


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
            else if(item is IBooking booking)
            {
                _bookings.Add(booking);
            }

            
        }

        public void AddCustomer(string lName, string fName, int SSN) { }

      
    }
}
