using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Repository.Interface
{
    public interface IBookingRepository
    {
        List<Booking> GetBookingsByUser(String username);

    }
}
