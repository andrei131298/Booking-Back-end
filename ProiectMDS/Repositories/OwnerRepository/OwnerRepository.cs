using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.OwnerRepository
{
    public class OwnerRepository : IOwnerRepository
    {
        public Context _context { get; set; }
        public OwnerRepository(Context context)
        {
            _context = context;
        }
        public Owner Create(Owner owner)
        {
            var result = _context.Add<Owner>(owner);
            _context.SaveChanges();
            return result.Entity;
        }
        public Owner Get(int Id)
        {
            return _context.Owners.SingleOrDefault(x => x.id == Id);
        }

        public List<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner Update(Owner owner)
        {
            _context.Entry(owner).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return owner;
        }

        public Owner Delete(Owner owner)
        {
            var result = _context.Remove(owner);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

