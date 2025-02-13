using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModelsFromMusicStore;

namespace TravelAgency.Domain.DTO
{
    public class AlbumArtistDTO
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Genre { get; set; }
        public string? ArtistImage { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
