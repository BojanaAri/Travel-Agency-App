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
        private readonly IBookingRepository _bookingRepository1;
        private readonly IUserService _userService;
        private readonly ITravelPackageService _travelPackageService;

        public BookingService(IRepository<Booking> bookingRepository, IBookingRepository bookingRepository1, IUserService userService, ITravelPackageService travelPackageService)
        {
            _bookingRepository = bookingRepository;
            _bookingRepository1 = bookingRepository1;
            _userService = userService;
            _travelPackageService = travelPackageService;
        }

        public Booking CreateNewBooking(string userId, Guid travelPackageId, int numRooms)
        {
            Booking booking = new Booking();
            booking.Id = Guid.NewGuid();
            booking.UserId = userId;
            booking.User = _userService.getUserByUsername(booking.UserId);
            booking.TravelPackageId = travelPackageId;

            TravelPackage travelPackage= _travelPackageService.GetTravelPackageById(travelPackageId);
            booking.TravelPackage = travelPackage;

            booking.NumberOfRooms = numRooms;

            Accommodation accommodation= travelPackage.Accommodation;

            booking.FullPrice = accommodation.PricePerNight * travelPackage.NumberOfNights * numRooms;
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
            return _bookingRepository1.GetBookingsByUser(username);
        }

        public Booking UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
