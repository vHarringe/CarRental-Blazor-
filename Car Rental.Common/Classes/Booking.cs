using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int BookingId { get; set; }
    public int CustomerId { get; set; }
    public int VehicleId { get; set; }
    



}