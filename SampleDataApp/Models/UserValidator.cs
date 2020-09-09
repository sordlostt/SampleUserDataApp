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
        public static bool ValidateUserProperties(IUser user)
        {
            foreach (PropertyInfo property in user.GetType().GetProperties())
            {
                var value = property.GetValue(user);
                if (property.PropertyType == typeof(string) && value as string == "" && property.Name != "ApartmentNumber")
                {
                    return false;
                }
            }

            return true;
        }
    }
}
