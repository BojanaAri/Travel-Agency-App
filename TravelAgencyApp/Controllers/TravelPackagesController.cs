using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.ViewModels;
using TravelAgency.Services.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Web.Controllers
{
    public class TravelPackagesController : Controller
    {
        private readonly ITravelPackageService _travelPackageService;
        private readonly IAccommodationService _accommodationService;

        public TravelPackagesController(ITravelPackageService travelPackageService, IAccommodationService accommodationService)
        {
            _travelPackageService = travelPackageService;
            _accommodationService = accommodationService;
        }

        // GET: TravelPackages
        public IActionResult Index()
        {
            return View(_travelPackageService.GetTravelPackages());
        }

        // GET: TravelPackages/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPackage = _travelPackageService.GetTravelPackageById(id);
                
            if (travelPackage == null)
            {
                return NotFound();
            }

            return View(travelPackage);
        }

        // GET: TravelPackages/Create
        public IActionResult Create()
        {
            var viewModel = new TravelPackageViewModel
            {
                Accommodations = _accommodationService.GetAccommodations()
            };

            return View(viewModel);
        }

        // POST: TravelPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelPackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accommodation = _accommodationService.GetAccommodationById(model.SelectedAccommodationId);
                var travelPackage = new TravelPackage
                {
                    Name = model.Name,
                    Description = model.Description,
                    DepartureDate = model.DepartureDate,
                    AccommodationId = model.SelectedAccommodationId,
                    Accommodation = accommodation,
                    AvailableRooms = accommodation.MaxNumberOfRooms,
                    NumberOfNights = model.NumberOfNights,
                    Bookings = new List<Booking>(),
                    Itineraries = model.Itineraries
                    .Where(i => !string.IsNullOrWhiteSpace(i.Description) || !string.IsNullOrWhiteSpace(i.DayNumber.ToString()))
                    .Select(it => new Itinerary
                            {
                                Description = it.Description,
                                DayNumber = it.DayNumber,
                            }).ToList()
                };
                _travelPackageService.CreateNewTravelPackage(travelPackage);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: TravelPackages/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPackage = _travelPackageService.GetTravelPackageById(id) ;
            if (travelPackage == null)
            {
                return NotFound();
            }
            var viewModel = new TravelPackageViewModel
            {
                Id = travelPackage.Id,
                Name = travelPackage.Name,
                Description = travelPackage.Description,
                DepartureDate = travelPackage.DepartureDate,
                NumberOfNights= travelPackage.NumberOfNights,
                SelectedAccommodationId= travelPackage.AccommodationId,
                Accommodations = _accommodationService.GetAccommodations(),
                Itineraries = travelPackage.Itineraries?.ToList()
            };
            return View(viewModel);
        }

        // POST: TravelPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, TravelPackageViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var accommodation = _accommodationService.GetAccommodationById(model.SelectedAccommodationId);
                    var travelPackage = _travelPackageService.GetTravelPackageById(id);  
                    if (travelPackage == null)
                    {
                        return NotFound();
                    }
                   
                    travelPackage.Name = model.Name;
                    travelPackage.Description = model.Description;
                    travelPackage.DepartureDate = model.DepartureDate;
                    travelPackage.AccommodationId = model.SelectedAccommodationId;
                    travelPackage.Accommodation = accommodation;
                    travelPackage.AvailableRooms = accommodation.MaxNumberOfRooms;
                    travelPackage.NumberOfNights = model.NumberOfNights;

                    travelPackage.Itineraries?.Clear();
                    travelPackage.Itineraries.AddRange(model.Itineraries?
                        .Where(i => !string.IsNullOrWhiteSpace(i.Description) || !string.IsNullOrWhiteSpace(i.DayNumber.ToString()))
                        .Select(i => new Itinerary
                        {
                            DayNumber = i.DayNumber,
                            Description = i.Description
                        }));

                    _travelPackageService.UpdateTravelPackage(travelPackage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelPackageExists(model.Id))
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
            return View(model);
        }

        // GET: TravelPackages/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPackage = _travelPackageService.GetTravelPackageById(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            return View(travelPackage);
        }

        // POST: TravelPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _travelPackageService.DeleteTravelPackage(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TravelPackageExists(Guid id)
        {
            return _travelPackageService.GetTravelPackageById(id) != null;
        }
    }
}
