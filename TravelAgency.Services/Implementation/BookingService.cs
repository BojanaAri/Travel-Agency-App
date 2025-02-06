using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Booking> _bookingRepository;

        public BookingService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking CreateNewBooking(Booking booking)
        {
           return  _bookingRepository.Insert(booking);
        }

        public Booking DeleteBooking(Guid id)
        {
            Booking booking = _bookingRepository.Get(id);
            return _bookingRepository.Delete(booking);
        }

        public Booking GetBookingById(Guid? id)
        {
            return _bookingRepository.Get(id);
        }

        public List<Booking> GetBookings()
        {
            return _bookingRepository.GetAll().ToList();
        }

        public List<Booking> GetBookingsByUser(string username)
        {
            throw new NotImplementedException();
        }

        public Booking UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
