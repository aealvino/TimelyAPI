using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
