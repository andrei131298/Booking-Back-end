using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.PropertyRepository
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        Property Get(int id);
        Property Create(Property Property);
        Property Update(Property Property);
        Property Delete(Property Property);
    }
}
