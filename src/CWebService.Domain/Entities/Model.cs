using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace CWebService.Domain.Entities
{
    public class Model
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual long BrandId { get; set; }
        // public virtual Brand Brand { get; set; }
    }
}