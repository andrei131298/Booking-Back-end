using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.UserRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserRepository repository)
        {
            IUserRepository = repository;
        }
        public IUserRepository IUserRepository { get; set; }
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return IUserRepository.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return IUserRepository.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public User Post(UserDTO value)
        {
            User model = new User()
            {
                firstName = value.firstName,
                lastName = value.lastName,
                sex = value.sex,
                birthDate = value.birthDate,
                bankAccount = value.bankAccount,
                email = value.email,
                password = value.password
            };
            return IUserRepository.Create(model);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public User Put(int id, UserDTO value)
        {
            User model = IUserRepository.Get(id);
            if (value.firstName != null)
            {
                model.firstName = value.firstName;
            }
            if (value.lastName != null)
            {
                model.lastName = value.lastName;
            }
            if (value.sex != null)
            {
                model.sex = value.sex;
            }
            if (value.birthDate != null)
            {
                model.birthDate = value.birthDate;
            }
            if (value.bankAccount != null)
            {
                model.bankAccount = value.bankAccount;
            }
            if (value.email != null)
            {
                model.email = value.email;
            }
            if (value.password != null)
            {
                model.password = value.password;
            }
            return IUserRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            User model = IUserRepository.Get(id);
            return IUserRepository.Delete(model);
        }
    }
}
