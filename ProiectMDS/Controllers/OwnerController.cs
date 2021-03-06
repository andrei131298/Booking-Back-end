﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.OwnerRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public OwnerController(IOwnerRepository repository)
        {
            IOwnerRepository = repository;
        }
        public IOwnerRepository IOwnerRepository { get; set; }
        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return IOwnerRepository.GetAll();
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return IOwnerRepository.Get(id);
        }

        // POST: api/Owner
        [HttpPost]
        public Owner Post(OwnerDTO value)
        {
            Owner model = new Owner()
            {
                firstName = value.firstName,
                lastName = value.lastName
            };
            return IOwnerRepository.Create(model);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public Owner Put(int id, OwnerDTO value)
        {
            Owner model = IOwnerRepository.Get(id);
            if (value.firstName != null)
            {
                model.firstName = value.firstName;
            }
            if (value.lastName != null)
            {
                model.lastName = value.lastName;
            }

            return IOwnerRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Owner Delete(int id)
        {
            Owner model = IOwnerRepository.Get(id);
            return IOwnerRepository.Delete(model);
        }
    }
}
