using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Identity;

namespace TravelAgency.Repository.Interface
{
    public interface IUserRepository
    {
        TravelAgencyUser getUserByUsername(string username);
    }
}
