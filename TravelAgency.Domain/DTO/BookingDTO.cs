using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Domain.DTO
{
    public class BookingDTO
    {
        public Guid travelPackageId { get; set; }
        public int numberOfRooms { get; set; }
    }
}
