using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BasicWepApiDbContext _context;
        public CompanyRepository(BasicWepApiDbContext context)
        {
            _context = context;
        }
        public int Add(Company item)
        {
            _context.Companies.Add(item);
            return _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Company company = GetById(id);

            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return _context.Companies.ToList();

        }

        public Company GetById(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Company item)
        {
            _context.Companies.Update(item);
            _context.SaveChanges();
        }
    }
}
