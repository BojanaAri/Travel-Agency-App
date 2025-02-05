using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IRepository<Accommodation> _accommodationRepository;
        public AccommodationService(IRepository<Accommodation> accommodationRepository) 
        { 
            _accommodationRepository = accommodationRepository;
        }

        public Accommodation CreateNewAccommodation(Accommodation accommodation)
        {
            return _accommodationRepository.Insert(accommodation);
        }

        public Accommodation DeleteAccommodation(Guid id)
        {
            var acc = this.GetAccommodationById(id);
            return _accommodationRepository.Delete(acc);
        }

        public List<Accommodation> GetAccommodations()
        {
            return _accommodationRepository.GetAll().ToList();
        }

        public Accommodation GetAccommodationById(Guid? id)
        {
            return _accommodationRepository.Get(id);
        }

        public Accommodation UpdateAccommodation(Accommodation accommodation)
        {
            return _accommodationRepository.Update(accommodation);
        }
    }
}
