using SampleDataApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SampleDataApp.Models
{
    [DataContract(Name = "User", Namespace = "")]
    public class User : ObservableObject,IUser
    {
        private DateTime _birthday;
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public string HouseNumber { get; set; }
        [DataMember]
        public string ApartmentNumber { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }

            set 
            {
                _birthday = value;
                OnPropertyChanged("Age");
            }
        }
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
