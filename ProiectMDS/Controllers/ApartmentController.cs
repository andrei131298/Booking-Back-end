using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ApartmentRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        public ApartmentController(IApartmentRepository repository)
        {
            IApartmentRepository = repository;
        }
        public IApartmentRepository IApartmentRepository { get; set; }
        // GET: api/Apartment
        [HttpGet]
        public ActionResult<IEnumerable<Apartment>> Get()
        {
            return IApartmentRepository.GetAll();
        }

        // GET: api/Apartment/5
        [HttpGet("{id}")]
        public ActionResult<Apartment> Get(int id)
        {
            return IApartmentRepository.Get(id);
        }

        // POST: api/Apartment
        [HttpPost]
        public Apartment Post(ApartmentDTO value)
        {
            Apartment model = new Apartment()
            {
                numberOfRooms = value.numberOfRooms,
                description = value.description,
                pricePerNight = value.pricePerNight,
                propertyId = value.propertyId

            };
            return IApartmentRepository.Create(model);
        }

        // PUT: api/Apartment/5
        [HttpPut("{id}")]
        public Apartment Put(int id, ApartmentDTO value)
        {
            Apartment model = IApartmentRepository.Get(id);
            if (value.description != null)
            {
                model.description = value.description;
            }
            if (value.numberOfRooms != 0)
            {
                model.numberOfRooms = value.numberOfRooms;
            }
            if (value.propertyId != 0)
            {
                model.propertyId = value.propertyId;
            }
            if (value.pricePerNight != 0)
            {
                model.pricePerNight = value.pricePerNight;
            }
            return IApartmentRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Apartment Delete(int id)
        {
            Apartment model = IApartmentRepository.Get(id);
            return IApartmentRepository.Delete(model);
        }
    }
}
