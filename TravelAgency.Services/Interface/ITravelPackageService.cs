using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Services.Interface
{
    public interface ITravelPackageService
    {
        public List<TravelPackage> GetTravelPackages();
        public TravelPackage GetTravelPackageById(Guid? id);
        public TravelPackage CreateNewTravelPackage(TravelPackage travelPackage);
        public TravelPackage UpdateTravelPackage(TravelPackage travelPackage);
        public TravelPackage DeleteTravelPackage(Guid id);
    }
}
