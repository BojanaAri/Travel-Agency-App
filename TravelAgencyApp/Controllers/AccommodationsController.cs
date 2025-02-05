using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Services.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Web.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly IAccommodationService _accommodationService;

        public AccommodationsController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }

        // GET: Accommodations
        public IActionResult Index()
        {
            return View(_accommodationService.GetAccommodations());
        }

        // GET: Accommodations/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = _accommodationService.GetAccommodationById(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // GET: Accommodations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accommodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,accommodationType,PricePerNight,MaxNumberOfRooms")] Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                _accommodationService.CreateNewAccommodation(accommodation);
                return RedirectToAction(nameof(Index));
            }
            return View(accommodation);
        }

        // GET: Accommodations/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = _accommodationService.GetAccommodationById(id);
            if (accommodation == null)
            {
                return NotFound();
            }
            return View(accommodation);
        }

        // POST: Accommodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Address,accommodationType,PricePerNight,MaxNumberOfRooms")] Accommodation accommodation)
        {
            if (id != accommodation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _accommodationService.UpdateAccommodation(accommodation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccommodationExists(accommodation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accommodation);
        }

        // GET: Accommodations/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accommodation = _accommodationService.GetAccommodationById(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return View(accommodation);
        }

        // POST: Accommodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _accommodationService.DeleteAccommodation(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AccommodationExists(Guid id)
        {
            return _accommodationService.GetAccommodationById(id) != null;
        }
    }
}
