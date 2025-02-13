using TravelAgency.Domain.DomainModelsFromMusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class ArtistService : IArtistsService
    {
        private IRepository<Artist> _artistRepository;
        public ArtistService(IRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public void CreateArtist(Artist artist)
        {
             _artistRepository.Insert(artist);
        }

        public void DeleteArtist(Guid id)
        {
            var artist = this.GetArtistById(id);
            _artistRepository.Delete(artist);
        }

        public List<Artist> GetAllArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public Artist GetArtistById(Guid id)
        {
            return _artistRepository.Get(id);
        }

        public void UpdateArtist(Artist artist)
        {
            _artistRepository.Update(artist);
        }
    }
}
