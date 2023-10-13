namespace Car_Rental.Common.Exceptions;

public class DataNotImplementedException : Exception
{
    public DataNotImplementedException() : base("Data access for this type is not implemented.")
    {

    }
}
