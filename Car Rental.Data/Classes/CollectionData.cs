﻿using Car_Data;
using Car_Rental.Common.Classes;
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

        
        public void Add<T>(T item)
        {
            if(item == null) throw new ArgumentNullException("item");
            else if(item is IPerson person)
            {
                _persons.Add(person);
            }



        }
        public void AddCustomer(string lName, string fName, int SSN) { }























        public IEnumerable<T> Get<T>(Func<T, bool> filter = null)
        {
            if (typeof(T) == typeof(IPerson))
            {


                return (IEnumerable<T>)_persons;

            }

            return null;

            
        }

       

       



    }
}