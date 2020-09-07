using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.UserRepository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        User Create(User User);
        User Update(User User);
        User Delete(User User);
    }
}