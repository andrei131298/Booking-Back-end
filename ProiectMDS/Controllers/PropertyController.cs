using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.PropertyRepository;
using ProiectMDS.Repositories.CityRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public PropertyController(IPropertyRepository repository)
        {
            IPropertyRepository = repository;
        }
        public IPropertyRepository IPropertyRepository { get; set; }
        public ICityRepository ICityRepository { get; set; }
        // GET: api/Property
        [HttpGet]
        public ActionResult<IEnumerable<Property>> Get()
        {
            return IPropertyRepository.GetAll();
        }

        // GET: api/Property/5
        [HttpGet("{id}")]
        public ActionResult<Property> Get(int id)
        {
            return IPropertyRepository.Get(id);
        }

        // POST: api/Property
        [HttpPost]
        public Property Post(PropertyDTO value)
        {
            Property model = new Property()
            {
                type = value.type,
                description = value.description,
                numberOfStars = value.numberOfStars,
                street = value.street,
                streetNumber = value.streetNumber,
                photo = value.photo,
                cityId = value.cityId,
                ownerId = value.ownerId
            };
            return IPropertyRepository.Create(model);
        }

        // PUT: api/Property/5
        [HttpPut("{id}")]
        public Property Put(int id, PropertyDTO value)
        {
            Property model = IPropertyRepository.Get(id);
            if (value.type != null)
            {
                model.type = value.type;
            }
            if (value.description != null)
            {
                model.description = value.description;
            }
            if (value.numberOfStars != 0)
            {
                model.numberOfStars = value.numberOfStars;
            }
            if (value.street != null)
            {
                model.street = value.street;
            }
            if (value.streetNumber != 0)
            {
                model.streetNumber = value.streetNumber;
            }
            if (value.photo != null)
            {
                model.photo = value.photo;
            }
            if (value.cityId != 0)
            {
                model.cityId = value.cityId;
            }
            if (value.ownerId != 0)
            {
                model.ownerId = value.ownerId;
            }
            return IPropertyRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Property Delete(int id)
        {
            Property model = IPropertyRepository.Get(id);
            return IPropertyRepository.Delete(model);
        }
    }
}
