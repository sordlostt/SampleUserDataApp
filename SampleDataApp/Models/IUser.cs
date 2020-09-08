using System;

namespace SampleDataApp.Models
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string Town { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        int Age { get; }
    }
}