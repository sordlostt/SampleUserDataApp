using GalaSoft.MvvmLight.Messaging;
using SampleDataApp.Models;
using SampleDataApp.ViewModels.Commands;
using SampleDataApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;

namespace SampleDataApp.ViewModels
{
    public class AddUserWindowViewModel : ObservableObject
    {
        public static bool CanOpen { get; set; } = true;
        public string ApartmentNumber { get; set; }
        public string Birthday { get; set; }
        public string FirstName { get; set; }
        public string HouseNumber { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public int Age { get; }

        public DelegateCommandExecutor ExecuteAddUser { get; private set; }
        public DelegateCommandExecutor ExecuteCloseWindow { get; private set; }

        public AddUserWindowViewModel()
        {
            ExecuteAddUser = new DelegateCommandExecutor(AddUser);
            ExecuteCloseWindow = new DelegateCommandExecutor(CloseWindow);
        }

        public void AddUser()
        {
            if(!UserValidator.ValidateBirthday(Birthday))
            {
                MessageBox.Show("Please fill all requested information correctly.");
            }
            else
            {
                IUser newUser = new User()
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    ApartmentNumber = this.ApartmentNumber,
                    Birthday = DateTime.Parse(Birthday),
                    HouseNumber = this.HouseNumber,
                    PhoneNumber = this.PhoneNumber,
                    PostalCode = this.PostalCode,
                    StreetName = this.StreetName,
                    Town = this.Town
                };

                //Make sure the user filled the form with all requested information
                if(UserValidator.ValidateUserProperties(newUser))
                {
                    MainWindowViewModel.Users.Add(newUser);
                    CloseWindow();
                }
                else
                {
                    MessageBox.Show("Please fill all requested information correctly.");
                }
            }
        }

        //Close the window using Messenger from MVVM Light toolkit,
        //the most simple and efficient method of closing views through a view model in MVVM that I could find 
        public void CloseWindow()
        {
            CanOpen = true;
            Messenger.Default.Send(new NotificationMessage("Close"));
        }

        //If user decides to close the view with the cross button, set CanOpen to true in orded to allow the window to be reopened
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            CanOpen = true;
        }
    }
}
