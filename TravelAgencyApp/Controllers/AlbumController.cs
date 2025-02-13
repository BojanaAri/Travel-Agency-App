using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.DTO;
using TravelAgency.Services.Implementation;
using TravelAgency.Services.Interface;

namespace TravelAgency.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IArtistsService _artistsService;
        private readonly IAccommodationService _accommodationService;

        public AlbumController(IAlbumService albumService, IArtistsService artistsService)
        {
            _albumService = albumService;
            _artistsService = artistsService;
        }


        public IActionResult Index()
        {
            var artists = _artistsService.GetAllArtists();

            var dto = artists.Select(a => new AlbumArtistDTO
            {
                Name = a.Name,
                ArtistImage = a.ArtistImage,
                Country = a.Country,   
                Genre = a.Genre,   
                Albums = _albumService.GetAlbumsByArtist(a.Id)
            }).ToList();
           
            return View(dto);
        }
    }
}
