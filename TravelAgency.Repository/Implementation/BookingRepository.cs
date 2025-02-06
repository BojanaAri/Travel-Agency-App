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


        public BookingRepository(ApplicationDbContext context, DbSet<Booking> entities)
        {
            this.entities = entities;
            this.context = context;
        }

        
        public List<Booking> GetBookingsByUser(string username)
        {
            return entities.ToList();
              //  .AllAsync(b => b.UserId == username);
        }
    }
}
