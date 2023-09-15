using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicle
    {

        string model { get; }
        string make { get; }
        int costDay { get;}
        int costKM { get;}
        int vehicleID { get;}




    }
}
