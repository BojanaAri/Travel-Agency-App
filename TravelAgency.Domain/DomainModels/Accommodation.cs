using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.DomainModels
{
    public class Accommodation : BaseEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public AccommodationType? accommodationType { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxNumberOfRooms { get; set; }
        public virtual ICollection<TravelPackageAccommodationStay>? TravelPackageAccommodationStays { get; set; }
    }
}
