using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;

namespace TravelAgency.Services.Interface
{
    public interface IBookingService
    {
        public List<Booking> GetBookings();
        public Booking GetBookingById(Guid? id);
        public List<Booking> GetBookingsByUser(String username);
        public Booking CreateNewBooking(string userId, Guid travelPackageId, int numRooms);
        public Booking UpdateBooking(Booking booking);
        public Booking DeleteBooking(Guid id);
    }
}
