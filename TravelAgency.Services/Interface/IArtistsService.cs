using TravelAgency.Domain.DomainModelsFromMusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Services.Interface
{
    public interface IArtistsService
    {
        List<Artist> GetAllArtists();
        Artist GetArtistById(Guid id);
        void CreateArtist(Artist artist);
        void UpdateArtist(Artist artist);
        void DeleteArtist(Guid id);
    }
}
