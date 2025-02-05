using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Domain.ViewModels
{
    public class TravelPackageViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(1,365, ErrorMessage = "Number of nights must be between 1 and 365 days")]
        public decimal NumberOfNights { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public virtual DateTime DepartureDate { get; set; }
        [Required(ErrorMessage = "Select an accommodation")]
        public Guid? SelectedAccommodationId { get; set; }
        public List<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
        public List<Itinerary>? Itineraries { get; set; } = new List<Itinerary>();
    }
}
