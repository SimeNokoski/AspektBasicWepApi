using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BasicWepApiDbContext _context;
        public CountryRepository(BasicWepApiDbContext context)
        {
            _context = context;
        }
        public int Add(Country item)
        {
            _context.Countries.Add(item);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
           Country country = GetById(id);
           _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Country item)
        {
            _context.Countries.Update(item);
            _context.SaveChanges();
        }
    }
}
