using Car_Rental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicle
    {

       
        string make { get; }
        int? odometer { get; }
        int? costDay { get;}
        int? costKM { get;}
        string regNo { get;}

        bool available { get; }
        int? SelectedCustomerId { get; set; }
        public VehicleTypes? VehicleType { get; set; }


    }
}
