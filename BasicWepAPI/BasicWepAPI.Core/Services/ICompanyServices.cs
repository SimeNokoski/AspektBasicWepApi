using BasicWepAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicWepAPI.Core.Services
{
    public interface ICompanyServices<T>
    {
        List<T> GetAllCompany();
        T GetCompanyById(int id);
        void CreateCompany(T items);
        void UpdateCompany(T items);
        void DeleteCompany(int id);
    }
}
