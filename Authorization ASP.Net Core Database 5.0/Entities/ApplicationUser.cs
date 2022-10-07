using Microsoft.AspNetCore.Identity;
using System;

namespace Authorization_ASP.Net_Core_Database_5._0.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
