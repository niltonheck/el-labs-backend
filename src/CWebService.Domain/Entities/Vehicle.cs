using System;
using System.ComponentModel.DataAnnotations;
using CWebService.Domain.Enums;
using Flunt.Notifications;

namespace CWebService.Domain.Entities
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Plate { get; set; }
        public Brand Brand  { get; set; }
        public Model Model { get; set; }
        public int Year { get; set; }
        public double CostPerHour { get; set; }
        public FuelType FuelType { get; set; }
        public double TrunkCapacity { get; set; }
        public Category Category { get; set; }
    }
}