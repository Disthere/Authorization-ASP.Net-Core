using Microsoft.AspNetCore.Identity;
using System;

namespace Authorization_ASP.Net_Core_Database_5._0.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
