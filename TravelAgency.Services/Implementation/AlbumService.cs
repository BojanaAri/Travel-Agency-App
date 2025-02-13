using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModelsFromMusicStore;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;
        public AlbumService(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public void CreateAlbum(Album album)
        {
            _albumRepository.Insert(album);
        }

        public void DeleteAlbum(Guid id)
        {
            var album = this.GetAlbumById(id);
            _albumRepository.Delete(album);
        }

        public Album GetAlbumById(Guid id)
        {
            return _albumRepository.Get(id);
        }

        public List<Album> GetAlbumsByArtist(Guid artistId)
        {
            return _albumRepository.GetAll()
                .Where(album => album.ArtistId == artistId)
                .ToList();
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public void UpdateAlbum(Album album)
        {
            _albumRepository.Update(album);
        }
    }
}
