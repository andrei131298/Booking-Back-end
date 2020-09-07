using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.FavouriteRepository
{
    public interface IFavouriteRepository
    {
        List<Favourite> GetAll();
        Favourite Get(int id);
        Favourite Create(Favourite Favourite);
        Favourite Update(Favourite Favourite);
        Favourite Delete(Favourite Favourite);
    }
}