using BasicWepAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        List<Contact> ContactWithCompanyAndCountry();
        List<Contact> FilterContacts(int? countryId, int? companyId);
        List<Contact> GetCompanyStatisticsByCountryId(int countryId);
    }
}
