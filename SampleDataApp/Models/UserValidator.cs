using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SampleDataApp.Models
{
    public static class UserValidator
    {
        /// <summary>
        /// Check if given birthday is in correct form.
        /// </summary>
        public static bool ValidateBirthday(string value)
        {
            DateTime temp;
            if (DateTime.TryParse(value, out temp))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if all requested user properties are filled.
        /// </summary>
        public static bool ValidateUserProperties(string firstName, string lastName, string streetName, string  houseNumber, string apartmentNumber, string postalCode, string town, string  phoneNumber)
        {
            IUser user = UserFactory.CreateUser(firstName, lastName, streetName, houseNumber, apartmentNumber, postalCode, town, phoneNumber, new DateTime());
            foreach (PropertyInfo property in user.GetType().GetProperties())
            {
                var value = property.GetValue(user);
                if (property.PropertyType == typeof(string) && value as string == "" && property.Name != "ApartmentNumber")
                {
                    //fixes the Save/Cancel buttons enabling on not all required fields filled
                    Messenger.Default.Send(new NotificationMessage("DisableButtons"));
                    return false;
                }
            }
            return true;
        }
    }
}
