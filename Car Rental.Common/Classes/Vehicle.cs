﻿using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;


public class Vehicle : IVehicle
{
    public int costDay { get; set; }
    public int costKM { get; set; }
    public int vehicleID { get; set; }
    public int Odometer { get; set; }
    public string RegNo { get; set; }


}
