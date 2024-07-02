using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Services
{
    public interface ICountryServices<T>
    {
        List<T> GetAllCountry();
        T GetCountryById(int id);
        void CreateCountry(T items);
        void UpdateCountry(T items);
        void DeleteCountry(int id);
    }
}
