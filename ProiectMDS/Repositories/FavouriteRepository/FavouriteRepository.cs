using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.FavouriteRepository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        public Context _context { get; set; }
        public FavouriteRepository(Context context)
        {
            _context = context;
        }
        public Favourite Create(Favourite favourite)
        {
            var result = _context.Add<Favourite>(favourite);
            _context.SaveChanges();
            return result.Entity;
        }
        public Favourite Get(int Id)
        {
            return _context.Favourites.SingleOrDefault(x => x.id == Id);
        }

        public List<Favourite> GetAll()
        {
            return _context.Favourites.ToList();
        }

        public Favourite Update(Favourite favourite)
        {
            _context.Entry(favourite).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return favourite;
        }

        public Favourite Delete(Favourite favourite)
        {
            var result = _context.Remove(favourite);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}


