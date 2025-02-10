using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.DTO;
using TravelAgency.Services.Implementation;
using TravelAgency.Services.Interface;
using TravelAgencyApp.Data;
using GemBox.Document;


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
        public IActionResult Index(bool showNotificationForSuccessfullyPaidBooking = false)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Booking> bookingsByUser = bookingService.GetBookingsByUser(userId);

            List<BookingDTO> bookingDTOs = bookingsByUser.Select(booking => new BookingDTO
                                            {
                                                BookingId = booking.Id,
                                                travelPackageId = booking.TravelPackageId,
                                                travelPackageName = booking.TravelPackage?.Name,
                                                accommodationName = booking.TravelPackage?.Accommodation?.Name,
                                                DepartureDate = booking.TravelPackage.DepartureDate,
                                                FullPrice = booking.FullPrice,
                                                numberOfRooms = booking.NumberOfRooms,
                                                username = booking.User?.UserName,
                                                NumberOfNights = booking.TravelPackage.NumberOfNights,
                                                PricePerNight = booking.TravelPackage.Accommodation.PricePerNight,
                                            }).ToList();
            if (showNotificationForSuccessfullyPaidBooking)
            {
                ViewData["showNotificationForSuccessfullyPaidBooking"] = true;
            }
            return View(bookingDTOs);
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

      //  GET: Bookings/Create?travelPackageId
        public IActionResult Create(Guid travelPackageId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.getUserByUsername(userId);
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
            var bookingDTO = new BookingDTO

            {
                travelPackageId = booking.TravelPackageId,
                numberOfRooms = booking.NumberOfRooms
            };
            ViewData["TravelPackageId"] = booking.TravelPackageId;
            ViewData["TravelPackageName"] = _travelPackageService.GetTravelPackageById(booking.TravelPackageId).Name;

            if (booking == null)
            {
                return NotFound();
            }
       
            return View(bookingDTO);
        }

        //// POST: Bookings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("numberOfRooms")] BookingDTO booking)
        {
            //if (id != booking.Id)
            //{
            //    return NotFound();
            //}

            Booking bookingObj = bookingService.GetBookingById(id);
            bookingObj.NumberOfRooms = booking.numberOfRooms;
            if (ModelState.IsValid)
            {
                try
                {
                    bookingService.UpdateBooking(bookingObj);
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

        public IActionResult PayOrder(Guid bookingId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var order = bookingService.Order(userId, bookingId);
            return RedirectToAction(nameof(Index), new { showNotificationForSuccessfullyPaidBooking = true});
        }

        public IActionResult ExportPdfOfBooking(Guid bookingId)
        {
            var result = bookingService.GetBookingById(bookingId);
           
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "invoice.docx");
            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{bookingId}}", bookingId.ToString());
            document.Content.Replace("{{username}}", result.User.Email);
            document.Content.Replace("{{travelPackage}}", result.TravelPackage.Name);
            document.Content.Replace("{{accommodation}}", result.TravelPackage.Accommodation.Name);
            document.Content.Replace("{{numNights}}", result.TravelPackage.NumberOfNights.ToString());
            document.Content.Replace("{{numRooms}}", result.NumberOfRooms.ToString());
            document.Content.Replace("{{totalPrice}}", result.FullPrice.ToString() + " $");

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }

    }
}
