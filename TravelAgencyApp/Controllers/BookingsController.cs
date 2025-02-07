using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.DTO;
using TravelAgency.Services.Implementation;
using TravelAgency.Services.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Web.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService bookingService;
        private readonly ITravelPackageService _travelPackageService;
        private readonly IUserService _userService;

        public BookingsController(IBookingService bookingService, ITravelPackageService travelPackageService, IUserService userService)
        {
            this.bookingService = bookingService;
            _travelPackageService = travelPackageService;
            _userService = userService;
        }

        //GET: Bookings
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(bookingService.GetBookingsByUser(userId));
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

      //  GET: Bookings/Create
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.getUserByUsername(userId);
            var travelPackageId = Guid.Parse("cff23f73-655f-42dd-51f7-08dd46acc282");
            ViewData["TravelPackageId"] = travelPackageId;
            ViewData["TravelPackageName"] = _travelPackageService.GetTravelPackageById(travelPackageId).Name;
            ViewData["User"] = user.FirstName + " " + user.LastName;
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("travelPackageId,numberOfRooms")] BookingDTO booking)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                bookingService.CreateNewBooking(userId,booking.travelPackageId,booking.numberOfRooms);
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
          //  ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id", booking.TravelPackageId);
            return View(booking);
        }

        //// POST: Bookings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TravelPackageId,UserId,NumberOfRooms,FullPrice,Id")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bookingService.UpdateBooking(booking);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!BookingExists(booking.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id", booking.TravelPackageId);
            return View(booking);
        }

        //// GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        //// POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var booking = bookingService.GetBookingById(id);
            if (booking != null)
            {
                bookingService.DeleteBooking(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool BookingExists(Guid id)
        //{
        //    return _context.Bookings.Any(e => e.Id == id);
        //}
    }
}
