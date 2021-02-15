using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWebService.Domain.Entities {
    public class UserProfile {
        public long Id { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName="Date")]
        public DateTime Birthday { get; set; }
        
        public long Zipcode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}