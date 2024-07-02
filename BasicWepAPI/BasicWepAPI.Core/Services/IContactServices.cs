using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Services
{
    public interface IContactServices<T, L>
    {
        List<T> GetAllContact();
        T GetContactById(int id);
        void CreateContact(T items);
        void UpdateContact(T items);
        void DeleteContact(int id);
        List<L> GetContactsWithCompanyAndCountry();
        List<L> FilterContact(int? countryId, int? companyId);
        Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId);
    }
}
