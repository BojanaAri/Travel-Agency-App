using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domain.DomainModels
{
    public class Itinerary : BaseEntity
    {
        public string? Description { get; set; }
        public int DayNumber { get; set; }
        public Guid TravelPackageId { get; set; } // Foreign Key
        public virtual TravelPackage? TravelPackage { get; set; }

    }
}
