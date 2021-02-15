using System;
using System.ComponentModel.DataAnnotations;
using CWebService.Domain.Enums;
using Flunt.Notifications;

namespace CWebService.Application.Models
{
    public class VehicleModel
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public long BrandId { get; set; }
        public long ModelId { get; set; }
        public virtual BrandModel Brand  { get; set; }
        public virtual ModelModel Model { get; set; }
        public int Year { get; set; }
        public double CostPerHour { get; set; }
        public FuelType FuelType { get; set; }
        public double TrunkCapacity { get; set; }
        public Category Category { get; set; }
        public Double SimulateCost(int numberOfHours) {
            return this.CostPerHour * numberOfHours;
        }
    }
}