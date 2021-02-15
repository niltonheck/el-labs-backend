using System;

public class BookingReturnRequestModel
{
    public long BookingId { get; set; }
    public bool IsCarClean { get; set; }
    public bool HasTankFullfilled { get; set; }
    public bool HasSmashes { get; set; }
    public bool HasScracthes { get; set; }

}