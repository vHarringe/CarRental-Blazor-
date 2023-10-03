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
    
    public int? KMRented { get; set; }

    public int? KMReturned { get; set; }
    public int? TotalCost { get; set; }

    public bool Status { get; set; } = false;

    public IPerson Customer { get; set; }

    public IVehicle Vehicle { get; set; }
    public DateTime BookingDate { get; set; }

    public DateTime? BookingReturned {  get; set; }

    public Booking(IVehicle vehicle, IPerson customer)
    {

        Vehicle = vehicle;
        Customer = customer;
        BookingDate = DateTime.Now;
        BookingReturned = null;
        KMRented = vehicle.odometer;
        KMReturned = null;
        Status = false;
        TotalCost = null;

    }
}