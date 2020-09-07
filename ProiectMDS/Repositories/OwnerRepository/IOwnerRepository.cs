using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.OwnerRepository
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
        Owner Get(int id);
        Owner Create(Owner Owner);
        Owner Update(Owner Owner);
        Owner Delete(Owner Owner);
    }
}
