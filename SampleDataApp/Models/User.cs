using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDataApp.Models
{
    public class User : IUser
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
        public int Age 
        {
            get
            {
                if (Birthday.Month >= DateTime.Today.Month && Birthday.Day > DateTime.Today.Day)
                {
                    return DateTime.Today.Year - Birthday.Year - 1;
                }
                else
                    return DateTime.Today.Year - Birthday.Year;
            }
        }
    }
}
