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
    public class TravelPackagesController : Controller
    {
        private readonly ITravelPackageService _travelPackageService;

        public TravelPackagesController(ITravelPackageService travelPackageService)
        {
            _travelPackageService = travelPackageService;
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
            return View();
        }

        // POST: TravelPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,NumberOfNights,DepartureDates")] TravelPackage travelPackage)
        {
            if (ModelState.IsValid)
            {
                _travelPackageService.CreateNewTravelPackage(travelPackage);
                return RedirectToAction(nameof(Index));
            }
            return View(travelPackage);
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
            return View(travelPackage);
        }

        // POST: TravelPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Description,NumberOfNights,DepartureDates")] TravelPackage travelPackage)
        {
            if (id != travelPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _travelPackageService.UpdateTravelPackage(travelPackage);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelPackageExists(travelPackage.Id))
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
            return View(travelPackage);
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
