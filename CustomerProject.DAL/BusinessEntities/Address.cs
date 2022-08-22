﻿using static CustomerProject.DAL.Enums;

namespace CustomerProject.DAL.BusinessEntities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
