using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Repository.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Booking> entities;


        public BookingRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Booking>();
        }

        public List<Booking> GetBookingsByUser(string username)
        {
            return entities.Include(b => b.User).Include(b => b.TravelPackage)
                .Where(b => b.UserId == username)
                .Include(b => b.TravelPackage)
                .Include(b => b.TravelPackage.Accommodation)    
                .ToList();
        }
    }
}
