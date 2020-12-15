using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        Reservation Get(int id);
        IEnumerable<Reservation> GetReservationsByUser(int userId);
        Reservation Create(Reservation Reservation);
        Reservation Update(Reservation Reservation);
        Reservation Delete(Reservation Reservation);
    }
}
