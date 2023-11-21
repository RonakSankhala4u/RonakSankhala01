using Microsoft.EntityFrameworkCore;
using RonakSankhala.Entities;
using RonakSankhala.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonakSankhala.Repositories.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities.Include(x => x.State).ThenInclude(y => y.Country).ToList();
        }

        public City GetById(int id)
        {
            return _context.Cities.Find(id);
        }

        public void RemoveData(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public void Save(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
    }
}
