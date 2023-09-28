using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
  
    public int? BookingId { get; set; }
    public int? CustomerId { get; set; }

    public Customer Customer { get; set; }
    public IVehicle Vehicle { get; set; }
    public DateTime BookingDate { get; set; }

    public Booking(int? customerId, IVehicle vehicle)
    {
        
        CustomerId = customerId;
        Vehicle = vehicle;
        

        BookingDate = DateTime.Now; 

    }
}