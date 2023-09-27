using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Motorcycle : Vehicle
{

    //public string Make {  get; set; }

    public Motorcycle(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available, VehicleTypes? vehicleType)
    {
        this.costDay = costDay;
        this.costKM = costKM;
        this.odometer = odometer;
        this.regNo = regNo;
        this.make = make;
        this.available = available;
        this.VehicleType = vehicleType;

    }


}