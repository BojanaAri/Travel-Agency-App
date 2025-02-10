using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.DomainModels;
using TravelAgency.Domain.Identity;
using TravelAgency.Repository.Interface;
using TravelAgencyApp.Data;

namespace TravelAgency.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(TravelPackage)))
            {
                return entities
                    .Include("Accommodation")
                    .Include("Itineraries")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Accommodation)))
            {
                return entities
                    .Include("TravelPackages")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(TravelAgencyUser)))
            {
                return entities
                    .Include("Bookings")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Booking)))
            {
                return entities
                     .Include("TravelPackage")
                     .Include("User")
                     .AsEnumerable();
            }
            else
            {
                return entities.AsEnumerable();
            }
        }
        public T Get(Guid? id)
        {
            if (typeof(T).IsAssignableFrom(typeof(TravelPackage)))
            {
                return entities
                    .Include("Accommodation")
                    .Include("Itineraries")
                    .First(x => x.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(Accommodation)))
            {
                return entities
                    .Include("TravelPackages")
                    .First(x => x.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(TravelAgencyUser)))
            {
                return entities
                    .Include("Bookings")
                    .First(x => x.Id == id);
            }
            else if(typeof(T).IsAssignableFrom(typeof(Booking)))
            {
                return entities
                    .Include("TravelPackage").Include("TravelPackage.Accommodation")
                   .Include("User")
                    .First(x => x.Id == id);
            }
            else
            {
                return entities.First(x => x.Id == id);
            }
        }


        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}
