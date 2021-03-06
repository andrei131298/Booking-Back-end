﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectMDS.Models;
using ProiectMDS.Contexts;

namespace ProiectMDS.Repositories.PhotoRepository
{
    public class PhotoRepository : IPhotoRepository
    {
        public Context _context { get; set; }
        public PhotoRepository(Context context)
        {
            _context = context;
        }
        public Photo Create(Photo photo)
        {
            var result = _context.Add<Photo>(photo);
            _context.SaveChanges();
            return result.Entity;
        }
        public Photo Get(int Id)
        {
            return _context.Photos.SingleOrDefault(x => x.id == Id);
        }

        public List<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public Photo Update(Photo photo)
        {
            _context.Entry(photo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return photo;
        }

        public Photo Delete(Photo photo)
        {
            var result = _context.Remove(photo);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}

