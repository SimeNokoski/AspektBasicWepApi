﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWepAPI.Core.Models
{
    public class Company : BaseEntity
    { 
        public string CompanyName { get; set; }
        public List<Contact> CompanyContacts { get; set; }

    }
}
