using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public Context _context { get; set; }
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            var result = _context.Add<User>(user);
            _context.SaveChanges();
            return result.Entity;
        }
        public User Get(int Id)
        {
            return _context.Users.SingleOrDefault(x => x.id == Id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            var result = _context.Remove(user);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

