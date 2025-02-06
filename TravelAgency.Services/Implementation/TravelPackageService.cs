using TravelAgency.Domain.DomainModels;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class TravelPackageService : ITravelPackageService
    {
        private readonly IRepository<TravelPackage> _travelPackageRepository;
      

        public TravelPackageService(IRepository<TravelPackage> travelPackageRepository) {
            _travelPackageRepository = travelPackageRepository;
        }

        public TravelPackage CreateNewTravelPackage(TravelPackage travelPackage)
        {
            return _travelPackageRepository.Insert(travelPackage);
        }

        public TravelPackage DeleteTravelPackage(Guid id)
        {
            var tp = this.GetTravelPackageById(id);
            return _travelPackageRepository.Delete(tp);
        }

        public TravelPackage GetTravelPackageById(Guid? id)
        {
            return _travelPackageRepository.Get(id);
        }

        public List<TravelPackage> GetTravelPackages()
        {
            return _travelPackageRepository.GetAll().ToList();
        }

        public TravelPackage UpdateTravelPackage(TravelPackage travelPackage)
        {

            return _travelPackageRepository.Update(travelPackage);
        }
    }
}
