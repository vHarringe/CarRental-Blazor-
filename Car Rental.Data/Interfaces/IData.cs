﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Data
{
    public interface IData
    {
        
        void AddCustomer(string lName, string fName, int SSN);

        public void Add<T>(T item);

        public List<T> Get<T>(Expression<Func<T, bool>>? expression = null);

        void SeedData();














   


    }
}
