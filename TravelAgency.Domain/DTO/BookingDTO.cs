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
        public Guid BookingId { get; set; }
        public Guid travelPackageId { get; set; }
        public int numberOfRooms { get; set; }
        public string? travelPackageName { get; set; }
        public string? accommodationName { get; set; }
        public virtual DateTime DepartureDate { get; set; }
        public decimal FullPrice { get; set; }
        public decimal PricePerNight { get; set; }
        public int NumberOfNights { get; set; }
        public string? username { get; set; }

    }
}
