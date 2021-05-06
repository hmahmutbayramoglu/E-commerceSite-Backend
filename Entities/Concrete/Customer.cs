using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer :IEntity
    {
        private string _customerId;

        private string _contactName;

        private string _companyName;

        private string _city;

        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string ContactName { get => _contactName; set => _contactName = value; }
        public string CompanyName { get => _companyName; set => _companyName = value; }
        public string City { get => _city; set => _city = value; }
    }
}
