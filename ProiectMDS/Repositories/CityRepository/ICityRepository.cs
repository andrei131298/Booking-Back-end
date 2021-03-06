﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.CityRepository
{
    public interface ICityRepository
    {
        List<City> GetAll();
        City Get(int id);
        City Create(City City);
        City Update(City City);
        City Delete(City City);

    }
}
