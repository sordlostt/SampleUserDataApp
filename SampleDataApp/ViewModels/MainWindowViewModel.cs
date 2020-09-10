using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;
using SampleDataApp.Models;
using SampleDataApp.Views;
using SampleDataApp.ViewModels.Commands;
using System.Collections.ObjectModel;
using XMLLogicLibrary;
using System.Xml.Serialization;

namespace SampleDataApp.ViewModels
{
    public class MainWindowViewModel
    {
        public static ObservableCollection<IUser> Users { get; set; }
        public OpenAddUserWindowCommand ExecuteOpenAddUserWindow { get; private set; }
        public RemoveUserCommand ExecuteRemoveUser { get; private set; }
        public DelegateCommandExecutor ExecuteSaveUsers { get; private set; }

        public MainWindowViewModel()
        {
            ExecuteOpenAddUserWindow = new OpenAddUserWindowCommand(OpenAddUserWindow);
            ExecuteRemoveUser = new RemoveUserCommand(RemoveUser);
            ExecuteSaveUsers = new DelegateCommandExecutor(SaveUsers);
            //Users = new ObservableCollection<IUser> { };
            if(!XMLFileManager.LoadFile())
            {
                XMLFileManager.CreateEmptyFile();
            }
            LoadUsers();
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

        public void SaveUsers()
        {
            XMLDataSerializer.SerializeUsers(new XMLUsers());
            XMLFileManager.SaveFile();
        }

        public void LoadUsers()
        {
            XMLUsers deserializedUsers = XMLDataSerializer.DeserializeUsers(new XMLUsers()) as XMLUsers;
            if (deserializedUsers.Users == null)
            {
                Users = new ObservableCollection<IUser> { };
            }
            else
            {
                Users = new ObservableCollection<IUser>(deserializedUsers.Users);
            }
        }
    }
}
