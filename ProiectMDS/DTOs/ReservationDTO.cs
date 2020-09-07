using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class ReservationDTO
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public int price { get; set; }
        public string review { get; set; }
        public int userId { get; set; }
        public int apartmentId { get; set; }

    }
}
