using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Flunt.Notifications;

namespace CWebService.Application.Models
{
    public class BrandModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}