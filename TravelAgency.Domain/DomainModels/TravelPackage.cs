using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domain.DomainModels
{
    public class TravelPackage : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal NumberOfNights { get; set; }
        public virtual DateTime DepartureDate { get; set; }
        public virtual ICollection<TravelPackageAccommodationStay>? TravelPackageAccommodationStays { get; set; }
        public virtual ICollection<Itinerary>? itineraries { get; set; }
    }
}
