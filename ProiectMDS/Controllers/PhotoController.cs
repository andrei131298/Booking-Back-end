﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.PhotoRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        public PhotoController(IPhotoRepository repository)
        {
            IPhotoRepository = repository;
        }
        public IPhotoRepository IPhotoRepository { get; set; }
        // GET: api/Photo
        [HttpGet]
        public ActionResult<IEnumerable<Photo>> Get()
        {
            return IPhotoRepository.GetAll();
        }

        // GET: api/Photo/5
        [HttpGet("{id}")]
        public ActionResult<Photo> Get(int id)
        {
            return IPhotoRepository.Get(id);
        }

        // POST: api/Photo
        [HttpPost]
        public Photo Post(PhotoDTO value)
        {
            Photo model = new Photo()
            {
                apartmentId = value.apartmentId,
                path = value.path
            };
            return IPhotoRepository.Create(model);
        }

        // PUT: api/Photo/5
        [HttpPut("{id}")]
        public Photo Put(int id, PhotoDTO value)
        {
            Photo model = IPhotoRepository.Get(id);
            if (value.path != null)
            {
                model.path = value.path;
            }
            if (value.apartmentId != 0)
            {
                model.apartmentId = value.apartmentId;
            }

            return IPhotoRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Photo Delete(int id)
        {
            Photo model = IPhotoRepository.Get(id);
            return IPhotoRepository.Delete(model);
        }
    }
}
