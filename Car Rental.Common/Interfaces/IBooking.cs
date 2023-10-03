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
        
        int? KMRented { get; set; }

        int? KMReturned { get; set; }

        int? TotalCost { get; set; }

        bool Status {  get; set; }

        public IPerson Customer { get; set; }
        IVehicle Vehicle { get; set; }
        DateTime BookingDate { get; set; }

        DateTime? BookingReturned {  get; set; }

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
