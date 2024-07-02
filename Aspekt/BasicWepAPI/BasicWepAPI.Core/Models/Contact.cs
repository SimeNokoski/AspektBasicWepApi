using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Models
{
    public class Contact : BaseEntity
    { 
        public string ContactName { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
