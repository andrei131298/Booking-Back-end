using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ReservationRepository;
using ProiectMDS.Repositories.UserRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public ReservationController(IReservationRepository repository)
        {
            IReservationRepository = repository;
        }
        public IReservationRepository IReservationRepository { get; set; }
        public IUserRepository IUSerRepository { get; set; }
        // GET: api/Reservation
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get()
        {
            return IReservationRepository.GetAll();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(int id)
        {
            return IReservationRepository.Get(id);
        }

        // POST: api/Reservation
        [HttpPost]
        public Reservation Post(ReservationDTO value)
        {
            Reservation model = new Reservation()
            {
                checkIn = value.checkIn,
                checkOut = value.checkOut,
                price = value.price,
                review = value.review,
                userId = value.userId,
                apartmentId = value.apartmentId
            };
            return IReservationRepository.Create(model);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public Reservation Put(int id, ReservationDTO value)
        {
            Reservation model = IReservationRepository.Get(id);
            if (value.review != null)
            {
                model.review = value.review;
            }         
            if (value.price != 0)
            {
                model.price = value.price;
            }
            if (value.checkIn != null)
            {
                model.checkIn = value.checkIn;
            }
            if (value.checkOut != null)
            {
                model.checkOut = value.checkOut;
            }
            if (value.userId != 0)
            {
                model.userId = value.userId;
            }
            if (value.apartmentId != 0)
            {
                model.apartmentId = value.apartmentId;
            }
            return IReservationRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Reservation Delete(int id)
        {
            Reservation model = IReservationRepository.Get(id);
            return IReservationRepository.Delete(model);
        }
    }
}
