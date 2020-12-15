using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ApartmentRepository;
using ProiectMDS.Repositories.PhotoRepository;




namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        public IApartmentRepository IApartmentRepository { get; set; }
        public IPhotoRepository IPhotoRepository { get; set; }
        public ApartmentController(IApartmentRepository apartmentrepository, IPhotoRepository photorepository)
        {
            IApartmentRepository = apartmentrepository;
            IPhotoRepository = photorepository;
        }
        // GET: api/Apartment
        [HttpGet]
        public ActionResult<IEnumerable<Apartment>> Get()
        {
            return IApartmentRepository.GetAll();
        }

        // GET: api/Apartment/5
        [HttpGet("{id}")]
        public ApartmentDTO Get(int id)
        {
            Apartment Apartment = IApartmentRepository.Get(id);
            ApartmentDTO MyApartments = new ApartmentDTO()
            {
                id = Apartment.id,
                apartmentName = Apartment.apartmentName,
                numberOfRooms = Apartment.numberOfRooms,
                description = Apartment.description,
                maxPersons = Apartment.maxPersons,
                pricePerNight = Apartment.pricePerNight,
                propertyId = Apartment.propertyId
            };
            IEnumerable<Photo> Photos = IPhotoRepository.GetAll().Where(x => x.apartmentId == Apartment.id);
            if (Photos != null)
            {
                List<string> PhotosPathsList = new List<string>();
                foreach (Photo Photo in Photos)
                {
                    PhotosPathsList.Add(Photo.path);
                }
                MyApartments.photos = PhotosPathsList;
            }
            return MyApartments;
        }

        // POST: api/Apartment
        [HttpPost]
        public Apartment Post(ApartmentDTO value)
        {
            Apartment model = new Apartment()
            {
                apartmentName = value.apartmentName,
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
