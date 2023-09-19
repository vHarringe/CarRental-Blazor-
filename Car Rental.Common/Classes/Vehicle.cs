using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;


public class Vehicle : IVehicle
{
    public int? costDay { get; set; }
    public int? costKM { get; set; }
    
    public int? odometer { get; set; }
    public string regNo { get; set; }
  
    public string make { get; set; }

    public bool available { get; set; }
}
