using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{

    //public string Make {  get; set; }
    
    public Car(int costDay, int costKM, int vehicleID, int odometer, string regNo, string model, string make) 
    {
        this.costDay = costDay;
        this.costKM = costKM;
        this.vehicleID = vehicleID;
        this.odometer = odometer;
        this.regNo = regNo;
        this.model = model;
        this.make = make;


    }
    

}