using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.DTOs
{
    public class PropertyDTO
    {
        public int id { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int numberOfStars { get; set; }
        public string street { get; set; }
        public int streetNumber { get; set; }
        public string photo { get; set; }

        public List<int> cityId { get; set; }
        public List<int> ownerId { get; set; }
    }
}
