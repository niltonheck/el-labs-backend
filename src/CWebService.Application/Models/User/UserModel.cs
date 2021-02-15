using System;
using CWebService.Domain.Enums;

namespace CWebService.Application.Models {
    public class UserModel {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual UserProfileModel Profile { get; set; }
    }
}