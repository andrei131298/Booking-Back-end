using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class PhotoDTO
    {
        public int id { get; set; }
        public int apartmentId { get; set; }
        public string path { get; set; }
    }
}
