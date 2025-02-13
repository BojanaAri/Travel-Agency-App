using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Domain.DomainModelsFromMusicStore
{
    public class Artist : BaseEntity
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Genre { get; set; }
        public string? ArtistImage { get; set; }

        // One-to-Many: Artist → Albums
        public  ICollection<Album>? Albums { get; set; }

    }
}
