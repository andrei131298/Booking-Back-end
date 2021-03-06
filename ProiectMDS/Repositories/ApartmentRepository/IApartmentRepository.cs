﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ApartmentRepository
{
    public interface IApartmentRepository
    {
        List<Apartment> GetAll();
        Apartment Get(int id);
        IEnumerable<Apartment> GetApartmentsByPropertyId(int propertyId);
        Apartment Create(Apartment Apartment);
        Apartment Update(Apartment Apartment);
        Apartment Delete(Apartment Apartment);
    }
}
