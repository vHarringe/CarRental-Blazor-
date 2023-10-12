using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

// basklass, måste ärvas. 
public abstract class Vehicle : IVehicle
{
    public int? costDay { get; set; }
    public int? costKM { get; set; }
    
    public int? odometer { get; set; }
    public string? regNo { get; set; }
  
    public string make { get; set; }

    public bool available { get; set; }

    public VehicleTypes? VehicleType { get; set; }
    

    public int? SelectedCustomerId {  get; set; }

    public int? OdometerReturned { get; set; }

    public bool RedFlagReturn { get; set; }
}
