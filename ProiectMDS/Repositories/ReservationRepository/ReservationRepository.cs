using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        public Context _context { get; set; }
        public ReservationRepository(Context context)
        {
            _context = context;
        }
        public Reservation Create(Reservation reservation)
        {
            var result = _context.Add<Reservation>(reservation);
            _context.SaveChanges();
            return result.Entity;
        }
        public Reservation Get(int Id)
        {
            return _context.Reservations.SingleOrDefault(x => x.id == Id);
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation Update(Reservation reservation)
        {
            _context.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return reservation;
        }

        public Reservation Delete(Reservation reservation)
        {
            var result = _context.Remove(reservation);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

