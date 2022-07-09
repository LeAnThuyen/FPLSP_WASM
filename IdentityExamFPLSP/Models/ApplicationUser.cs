using Microsoft.AspNetCore.Identity;

namespace ApiUser.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
