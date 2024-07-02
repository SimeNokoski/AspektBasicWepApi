using BasicWepAPI.Core.Models;
using BasicWepAPI.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly BasicWepApiDbContext _context;
        public ContactRepository(BasicWepApiDbContext context)
        {
            _context = context;
        }
        public int Add(Contact item)
        {
            _context.Contacts.Add(item);
            return _context.SaveChanges();
        }

        public List<Contact> ContactWithCompanyAndCountry()
        {
            return  _context.Contacts.Include(x=>x.Company).Include(x=>x.Country).ToList();
        }

        public void Delete(int id)
        {
            Contact contact = GetById(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public List<Contact> FilterContacts(int? countryId, int? companyId)
        {
            if (countryId == null && companyId == null)
            {
                return _context.Contacts.Include(x => x.Country).Include(x => x.Company).ToList();

            }
            if (countryId == null)
            {
                return _context.Contacts.Include(x=>x.Country).Include(x => x.Company).Where(x => x.CompanyId == companyId).ToList();

            }
            if (companyId == null)
            {
                return _context.Contacts.Include(x => x.Country).Include(x => x.Company).Where(x => x.CountryId == countryId).ToList();

            }
            return _context.Contacts.Include(x => x.Country).Include(x => x.Company).Where(x => x.CompanyId == companyId && x.CountryId == countryId).ToList();
        }

        public List<Contact> GetAll()
        {
           return _context.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Contact item)
        {
            _context.Contacts.Update(item);
            _context.SaveChanges();
        }

        public List<Contact> GetCompanyStatisticsByCountryId(int countryId)
        {
            return _context.Contacts.Include(x=>x.Company).Include(c=>c.Country).Where(c => c.CountryId == countryId).ToList();
        }
    }
}