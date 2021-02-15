using System;

namespace CWebService.Application.Models {
    public class UserProfileModel {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public long Zipcode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}