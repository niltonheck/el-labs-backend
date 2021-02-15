using System;

namespace CWebService.Domain.Entities
{
    public class Booking
    {
        public virtual long Id { get; set; }
        public virtual long VehicleId { get; set; }
        public virtual long UserId { get; set; }
        public virtual Double RentalAmount { get; set; }
        public virtual Double ExtraAmount { get; set; }
        public virtual Double TotalAmount { get; set; }
        public virtual DateTime InitialDateTime { get; set; }
        public virtual DateTime FinalDateTime { get; set; }
        public virtual int NumberOfHours { get; set; }

        
        
    }
}