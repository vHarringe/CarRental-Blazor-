using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;


public class Customer : IPerson
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Ssn { get; set; }

    public int CustomerId { get; set; }

   

    public Customer(string lName, string fName, int? SSN)
    {
        LastName = lName;
        FirstName = fName;
        Ssn = (int)SSN;
            
    }

}
