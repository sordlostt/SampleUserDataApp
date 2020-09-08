using SampleDataApp.Models;
using SampleDataApp.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDataApp.ViewModels
{
    public class AddUserWindowViewModel : ObservableObject
    {

        public int ApartmentNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public int HouseNumber { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public int Age { get; }

        public DelegateCommandExecutor ExecuteAddUser { get; private set; }

        public AddUserWindowViewModel()
        {
            ExecuteAddUser = new DelegateCommandExecutor(AddUser);
        }

        public void AddUser()
        {
            MainWindowViewModel.Users.Add(new User
            { 
                FirstName = this.FirstName,
                LastName = this.LastName,
                ApartmentNumber = this.ApartmentNumber, 
                Birthday = this.Birthday,
                HouseNumber = this.HouseNumber,
                PhoneNumber = this.PhoneNumber,
                PostalCode = this.PostalCode,
                StreetName = this.StreetName,
                Town = this.Town
            });
        }
    }
}
