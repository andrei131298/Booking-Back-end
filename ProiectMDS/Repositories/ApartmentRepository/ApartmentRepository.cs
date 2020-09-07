using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.ApartmentRepository
{
    public class ApartmentRepository : IApartmentRepository
    {
        public Context _context { get; set; }
        public ApartmentRepository(Context context)
        {
            _context = context;
        }
        public Apartment Create(Apartment adress)
        {
            var result = _context.Add<Apartment>(adress);
            _context.SaveChanges();
            return result.Entity;
        }
        public Apartment Get(int Id)
        {
            return _context.Apartments.SingleOrDefault(x => x.id == Id);
        }

        public List<Apartment> GetAll()
        {
            return _context.Apartments.ToList();
        }

        public Apartment Update(Apartment adress)
        {
            _context.Entry(adress).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return adress;
        }

        public Apartment Delete(Apartment adress)
        {
            var result = _context.Remove(adress);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

