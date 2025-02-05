﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Identity;

namespace TravelAgency.Domain.DomainModels
{
    public class Booking : BaseEntity
    {
     public Guid TravelPackageId {  get; set; }
     public Guid UserId { get; set; }
     public int NumberOfRooms { get; set; }
     public int FullPrice { get; set; }
     public virtual TravelPackage? TravelPackage { get; set; }
     public virtual TravelAgencyUser? User { get; set; }
    }
}
