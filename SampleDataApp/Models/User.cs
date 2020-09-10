using GalaSoft.MvvmLight.Messaging;
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
        private string _firstName;
        private string _lastName;
        private string _streetName;
        private string _houseNumber;
        private string _apartmentNumber;
        private string _postalCode;
        private string _town;
        private string _phoneNumber;
        private DateTime _birthday;

        [DataMember]
        public string FirstName 
        {
            get 
            { 
                return _firstName; 
            } 
            set 
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _firstName = value; 
            } 
        }
        [DataMember]
        public string LastName 
        { 
            get 
            { 
                return _lastName;
            } 
            set 
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _lastName = value; 
            }
        }
        [DataMember]
        public string StreetName 
        { 
            get 
            { 
                return _streetName;
            } 
            set
            {
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _streetName = value; 
            }
        }
        [DataMember]
        public string HouseNumber
        { 
            get
            { 
                return _houseNumber;
            } 
            set 
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _houseNumber = value;
            } 
        }
        [DataMember]
        public string ApartmentNumber 
        { 
            get 
            { 
                return _apartmentNumber;
            } 
            set
            {
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _apartmentNumber = value;
            } 
        }
        [DataMember]
        public string PostalCode
        {
            get
            { 
                return _postalCode;
            } 
            set
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _postalCode = value;
            } 
        }
        [DataMember]
        public string Town
        { 
            get
            { 
                return _town;
            } 
            set
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _town = value;
            } 
        }
        [DataMember]
        public string PhoneNumber {
            get
            {
                return _phoneNumber; 
            }
            set 
            { 
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
                _phoneNumber = value;
            } 
        }
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
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
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
