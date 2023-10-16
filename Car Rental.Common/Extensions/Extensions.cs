using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Extensions;

public static class Extensions
{
    public static IBooking CalcPrice(this IBooking booking)
    {
        if(booking.BookingReturned is not  null) 
        { 
           var time = booking.BookingDate - booking.BookingReturned;
           booking.TotalCost = booking.Vehicle.costKM * (booking.KMReturned - booking.Vehicle.odometer) + booking.Vehicle.costDay + (booking.Vehicle.costDay * time?.Days);
           return booking;
        }
        else
        { return booking; }
      
    }


}
