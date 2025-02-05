
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Identity
{
    public class TravelAgencyUser : IdentityUser
    {
        public UserRole UserRole { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
