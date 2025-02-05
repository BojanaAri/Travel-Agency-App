using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domain.DomainModels
{
    public class TravelPackageAccommodationStay : BaseEntity
    {
        public Guid AccommodationId { get; set; }
        public virtual Accommodation? Accommodation { get; set; }
        public Guid TravelPackageId { get; set; }
        public virtual TravelPackage? TravelPackage { get; set; }

        public DateTime? StartDate { get; set; }
        public int? AvailableRooms { get; set; }
    }
}
