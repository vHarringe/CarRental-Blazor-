using Car_Rental.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    {
        int? BookingId { get; set; }
        int? CustomerId { get; set; }

        public Customer Customer { get; set; }
        IVehicle Vehicle { get; set; }
        DateTime BookingDate { get; set; }

        /* 
            <th>RegNo</th>
            <th>Customer</th>
            <th>KM Rented</th>
            <th>KM Returned</th>d
            <th>rented</th>
            <th>returned</th>
            <th>Cost</th>
            <th>Status</th>
        */ 

    }
}
