using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;

namespace ProiectMDS.Repositories.PhotoRepository
{
    public interface IPhotoRepository
    {
        List<Photo> GetAll();
        Photo Get(int id);
        Photo Create(Photo Photo);
        Photo Update(Photo Photo);
        Photo Delete(Photo Photo);
    }
}
