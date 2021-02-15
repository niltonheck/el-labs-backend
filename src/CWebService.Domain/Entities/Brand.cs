using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace CWebService.Domain.Entities
{
    public class Brand
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}