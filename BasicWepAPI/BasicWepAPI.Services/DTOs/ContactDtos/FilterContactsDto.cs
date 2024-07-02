using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Services.DTOs.ContactDtos
{
    public class FilterContactsDto
    {
        public int ContactId { get; set; }
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public string ContactName { get; set; }
        public string CountryName { get; set; }
        public string CompanyName { get; set; }
    }
}
