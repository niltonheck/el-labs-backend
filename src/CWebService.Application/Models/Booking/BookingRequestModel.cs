using System;

public class BookingRequestModel
{
    public int VehicleId { get; set; }
    public int UserId { get; set; }
    public int NumberOfHours { get; set; }
    public DateTime InitialDateTime { get; set; }
    public DateTime FinalDateTime { get; set; }
}