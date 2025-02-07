using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Identity;
using TravelAgency.Repository.Interface;
using TravelAgency.Services.Interface;

namespace TravelAgency.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public TravelAgencyUser getUserByUsername(string username)
        {
            return userRepository.getUserByUsername(username);
        }
    }
}
