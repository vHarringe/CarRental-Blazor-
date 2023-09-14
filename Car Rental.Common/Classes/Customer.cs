using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;


public class Customer : IPerson
{
    public string? lastName { get; set; }
    public string? firstName { get; set; }
    public int Ssn { get; set; }

    public int customerId { get; set; }



}
