﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Identity;

namespace TravelAgency.Services.Interface
{
    public interface IUserService
    {
        TravelAgencyUser getUserByUsername(string username);
    }
}
