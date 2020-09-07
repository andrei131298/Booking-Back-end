﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.FavouriteRepository;
using ProiectMDS.Repositories.UserRepository;
using ProiectMDS.Repositories.PropertyRepository;



namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        public IFavouriteRepository IFavouriteRepository { get; set; }
        public IPropertyRepository IPropertyRepository { get; set; }
        public IUserRepository IUserRepository { get; set; }

        public FavouriteController(IFavouriteRepository repository)
        {
            IFavouriteRepository = repository;
        }
        // GET: api/Favourite
        [HttpGet]
        public ActionResult<IEnumerable<Favourite>> Get()
        {
            return IFavouriteRepository.GetAll();
        }

        // GET: api/Favourite/5
        [HttpGet("{id}")]
        public ActionResult<Favourite> Get(int id)
        {
            return IFavouriteRepository.Get(id);
        }

        // POST: api/Favourite
        [HttpPost]
        public Favourite Post(FavouriteDTO value)
        {
            Favourite model = new Favourite()
            {
                propertyId = value.propertyId,
                userId = value.userId
            };
            return IFavouriteRepository.Create(model);
        }

        // PUT: api/Favourite/5
        [HttpPut("{id}")]
        public Favourite Put(int id, FavouriteDTO value)
        {
            Favourite model = IFavouriteRepository.Get(id);
            if (value.propertyId != 0)
            {
                model.propertyId = value.propertyId;
            }
            if (value.userId != 0)
            {
                model.userId = value.userId;
            }

            return IFavouriteRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Favourite Delete(int id)
        {
            Favourite model = IFavouriteRepository.Get(id);
            return IFavouriteRepository.Delete(model);
        }
    }
}