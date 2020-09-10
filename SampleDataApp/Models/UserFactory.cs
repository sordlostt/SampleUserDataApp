using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDataApp.Models
{
    public static class UserFactory
    {
        public static IUser CreateUser(string firstName, string lastName, string streetName, string houseNumber, string apartmentNumber, string postalCode, string town, string phoneNumber, DateTime birthday)
        {
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                StreetName = streetName,
                HouseNumber = houseNumber,
                ApartmentNumber = apartmentNumber,
                PostalCode = postalCode,
                Town = town,
                PhoneNumber = phoneNumber,
                Birthday = birthday
            };

        }
    }
}
