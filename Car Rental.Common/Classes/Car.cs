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
    
    public Car(int? costDay, int? costKM, int? odometer, string regNo, string make, bool available) 
    {
        this.costDay = costDay;
        this.costKM = costKM;
        this.odometer = odometer;
        this.regNo = regNo;
        this.available = available;
        this.make = make;


    }
    

}