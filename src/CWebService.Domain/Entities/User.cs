using CWebService.Domain.Enums;

namespace CWebService.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}