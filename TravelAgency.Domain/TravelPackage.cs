using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domain
{
    public class TravelPackage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal NumberOfNights { get; set; }
        public ICollection<DateTime>? DepartureDates { get; set; }
        public Accommodation? accommodation { get; set; }
        public ICollection<Itinerary>? itineraries { get; set; }
    }
}
