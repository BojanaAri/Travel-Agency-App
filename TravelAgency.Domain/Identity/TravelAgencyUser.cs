using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Identity
{
    public class TravelAgencyUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }

        public static implicit operator TravelAgencyUser(ClaimsPrincipal v)
        {
            throw new NotImplementedException();
        }
    }
}