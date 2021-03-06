﻿using System;
using System.Collections.Generic;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;

namespace InvSys.Companies.Core.Models
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public byte[] Timestamp { get; set; }

        public string Exchange { get; set; }  
        public string Symbol { get; set; } // Ticker or Code
        public string Name { get; set; }
        public string Logo { get; set;}
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public DateTime? IPODate { get; set; }
        public string MarketValue { get; set; } // Market Capitalization
        public string Country { get; set; }

        public ICollection<CompanyTranslation> Translations { get; set; }
        public ICollection<Website> Websites { get; set; }
        public ICollection<Officer> Officers { get; set; }
    }

    public class CompanyTranslation : Translation
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public byte[] Timestamp { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        public string Sector { get; set; }
        public string Subsector { get; set; }
        public string Industry { get; set; }
    }
}
