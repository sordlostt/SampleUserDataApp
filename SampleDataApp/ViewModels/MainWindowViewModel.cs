using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using SampleDataApp.Models;
using SampleDataApp.Views;
using SampleDataApp.ViewModels.Commands;
using System.Collections.ObjectModel;

namespace SampleDataApp.ViewModels
{
    public class MainWindowViewModel
    {
        public static ObservableCollection<IUser> Users { get; set; }

        public OpenAddUserWindowCommand ExecuteOpenAddUserWindow { get; private set; }
        public RemoveUserCommand ExecuteRemoveUser { get; private set; }

        public MainWindowViewModel()
        {
            ExecuteOpenAddUserWindow = new OpenAddUserWindowCommand(OpenAddUserWindow);
            ExecuteRemoveUser = new RemoveUserCommand(RemoveUser);
            Users = new ObservableCollection<IUser> { };
        }

        public void OpenAddUserWindow()
        {
            //put some abstraction here
            AddUserWindowView addUserWindow = new AddUserWindowView();
            addUserWindow.Show();
            AddUserWindowViewModel.CanOpen = false;
        }

        public void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }
    }
}
