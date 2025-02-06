using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.DomainModels;
using TravelAgencyApp.Data;

namespace TravelAgency.Web.Controllers
{
    public class BookingsController : Controller
    {
       

        //public BookingsController(ApplicationDbContext context)
        //{
            
        //}

        //// GET: Bookings
        ////public async Task<IActionResult> Index()
        ////{
           
        ////}

        //// GET: Bookings/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var booking = await _context.Bookings
        //    //    .Include(b => b.TravelPackage)
        //    //    .FirstOrDefaultAsync(m => m.Id == id);
        //    //if (booking == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    return View(booking);
        //}

        //// GET: Bookings/Create
        //public IActionResult Create()
        //{
        //    ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id");
        //    return View();
        //}

        //// POST: Bookings/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TravelPackageId,UserId,NumberOfRooms,FullPrice,Id")] Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        booking.Id = Guid.NewGuid();
        //        _context.Add(booking);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id", booking.TravelPackageId);
        //    return View(booking);
        //}

        //// GET: Bookings/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var booking = await _context.Bookings.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id", booking.TravelPackageId);
        //    return View(booking);
        //}

        //// POST: Bookings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("TravelPackageId,UserId,NumberOfRooms,FullPrice,Id")] Booking booking)
        //{
        //    if (id != booking.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(booking);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookingExists(booking.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TravelPackageId"] = new SelectList(_context.TravelPackages, "Id", "Id", booking.TravelPackageId);
        //    return View(booking);
        //}

        //// GET: Bookings/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var booking = await _context.Bookings
        //        .Include(b => b.TravelPackage)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(booking);
        //}

        //// POST: Bookings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var booking = await _context.Bookings.FindAsync(id);
        //    if (booking != null)
        //    {
        //        _context.Bookings.Remove(booking);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookingExists(Guid id)
        //{
        //    return _context.Bookings.Any(e => e.Id == id);
        //}
    }
}
