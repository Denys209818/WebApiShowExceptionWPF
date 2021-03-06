using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiShowException.Entities.Identities
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
