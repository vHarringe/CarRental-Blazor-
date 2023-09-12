using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    {
       int BookingId { get; set; }
       int CustomerId { get; set; }
       int VehicleId { get; set; }


    }
}
