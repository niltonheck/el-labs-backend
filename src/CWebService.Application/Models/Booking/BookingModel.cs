using System;

public class BookingModel
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string VehicleLink {
        get {
            return "http://localhost:5000/v1/vehicles/" + VehicleId;
        }
     }
    public int UserId { get; set; }
    public string UserLink {
        get {
            return "http://localhost:5000/v1/users/" + UserId;
        }
     }
    public int NumberOfHours { get; set; }
    public Double RentalAmount { get; set; }
    public Double ExtraAmount { get; set; }
    public Double TotalAmount { get; set; }
    public DateTime InitialDateTime { get; set; }
    public DateTime FinalDateTime { get; set; }
    public string ReturnRequests {
        get {
            return "http://localhost:5000/v1/bookings/1/returnRequests";
        }
    }

    public void CalculateExtraCost(BookingReturnRequestModel returnModel) {
        if ( returnModel.HasScracthes ) { ExtraAmount += RentalAmount * 0.3; }
        if ( returnModel.HasSmashes ) { ExtraAmount += RentalAmount * 0.3; }
        if ( !returnModel.HasTankFullfilled ) { ExtraAmount += RentalAmount * 0.3; }
        if ( !returnModel.IsCarClean ) { ExtraAmount += RentalAmount * 0.3; }
    }

    public void CalculateTotalCost() {
        TotalAmount = RentalAmount + ExtraAmount;
    }
}