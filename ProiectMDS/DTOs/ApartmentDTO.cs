using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class ApartmentDTO
    {
        public int numberOfRooms { get; set; }
        public string description { get; set; }
        public int pricePerNight { get; set; }
        public int maxPersons { get; set; }
        public int propertyId { get; set; }
    }
}
