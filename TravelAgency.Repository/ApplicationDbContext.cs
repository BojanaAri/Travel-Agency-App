using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.Identity;

namespace TravelAgencyApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<TravelAgencyUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }

}
