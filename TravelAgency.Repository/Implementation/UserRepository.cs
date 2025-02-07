using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.Identity;
using TravelAgency.Repository.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TravelAgencyUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<TravelAgencyUser>();
        }

        
        public TravelAgencyUser getUserByUsername(string username)
        {
            return entities
                 .Where(u => u.Id == username).FirstOrDefault();
        }
    }
}
