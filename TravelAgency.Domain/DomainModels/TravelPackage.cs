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
        public Guid? AccommodationId { get; set; } 
        public virtual Accommodation? Accommodation { get; set; }
        public virtual ICollection<Itinerary>? Itineraries { get; set; }
        public int? AvailableRooms { get; set; }


    }
}
