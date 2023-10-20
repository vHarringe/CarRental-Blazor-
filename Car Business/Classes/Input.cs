using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Car_Business.Classes
{
    public class Input
    {
        #region LOKALA VARIABLER

        // bools
        public bool isDisabled = false;
        public bool alertCustomer = false;
        public bool alert = false;
        public bool isError = false;

        // add Customer
        public string? lName = null;
        public string? fName = null;
        public int? CustomerId = null;
        public int? Ssn = null;

        // lamda-filter (getVehicles)
        public int maxCost;
        public int minCost;
        public int costDayFilter;
        public int maxOdometer;
        public int minOdometer;
        public int odometerFilter;

        // add vehicle
        public int? costDay;
        public int? costKM;
        public int? odometer;
        public string? regNo;
        public string? make;
        public VehicleTypes? vehicleType;

        #endregion

        public void ClearError(IVehicle a)
        {
            a.RedFlagReturn = false;
        }
        public void CloseAlertCustomer()
        {
            alertCustomer = false;
        }
        public void CloseAlert()
        {
            alert = false;
        }

        public void UpdatePrice(ChangeEventArgs? price)
        {
            if (price != null && price.Value != null)
            {
                int.TryParse(price.Value.ToString(), out costDayFilter);
            }

        }
        public void UpdateOdometer(ChangeEventArgs? odometer)
        {
            if (odometer != null && odometer.Value != null)
            {
                int.TryParse(odometer.Value.ToString(), out odometerFilter);
            }

        }


    }
}
