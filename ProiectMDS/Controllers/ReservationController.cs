﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.ApartmentRepository;
using ProiectMDS.Repositories.PropertyRepository;
using ProiectMDS.Repositories.ReservationRepository;
using ProiectMDS.Repositories.UserRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public ReservationController(IReservationRepository repository,IApartmentRepository apartmentRepo,
            IPropertyRepository propertyRepo)
        {
            IReservationRepository = repository;
            IApartmentRepository = apartmentRepo;
            IPropertyRepository = propertyRepo;
        }
        public IReservationRepository IReservationRepository { get; set; }
        public IUserRepository IUSerRepository { get; set; }
        public IPropertyRepository IPropertyRepository { get; set; }
        public IApartmentRepository IApartmentRepository { get; set; }
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

        [HttpGet("user/{userId}")]
        /*
        public IEnumerable<Reservation> GetReservationsByUser(int userId)
        {
            return IReservationRepository.GetReservationsByUser(userId);
        }
        */
        public IEnumerable<ReservationDTO> GetReservationsByUser(int userId)
        {

            IEnumerable<Reservation> MyReservations = IReservationRepository.GetReservationsByUser(userId);
            List<ReservationDTO> ReservationsDTO = new List<ReservationDTO>();
            foreach (Reservation r in MyReservations)
            {
                ReservationDTO reservationDTO = new ReservationDTO()
                {
                    id = r.id,
                    checkIn = r.checkIn,
                    checkOut = r.checkOut,
                    price = r.price,
                    review = r.review,
                    userId = r.userId,
                    apartmentId = r.apartmentId,
                    numberOfPersons = r.numberOfPersons

                };
                ReservationsDTO.Add(reservationDTO);
            }
            foreach (ReservationDTO res in ReservationsDTO)
            {
                Apartment Apartment = IApartmentRepository.Get(res.apartmentId);
                res.apartmentName = Apartment.apartmentName;
                Property Property = IPropertyRepository.Get(Apartment.propertyId);
                res.propertyName = Property.name;
                res.propertyId = Property.id;
            }
            return ReservationsDTO;
        }
        [HttpGet, Route("dates")]
        public IEnumerable<Reservation> GetAlreadyReservedByDates(DateTime checkIn, DateTime checkOut)
        {
            return IReservationRepository.GetAlreadyReservedByDates(checkIn,checkOut);
        }

        // POST: api/Reservation
        [HttpPost]
        public Reservation Post(ReservationDTO value)
        {
            Reservation model = new Reservation()
            {
                checkIn = value.checkIn.ToLocalTime(),
                checkOut = value.checkOut.ToLocalTime(),
                price = value.price,
                review = value.review,
                userId = value.userId,
                apartmentId = value.apartmentId,
                numberOfPersons = value.numberOfPersons
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
            if (value.numberOfPersons != 0)
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
