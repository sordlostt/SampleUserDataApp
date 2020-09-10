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
using SampleDataApp.ViewModels.Misc;

namespace SampleDataApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<IUser> _users;
        public ObservableCollection<IUser> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public OpenAddUserWindowCommand ExecuteOpenAddUserWindow { get; private set; }
        public RemoveUserCommand ExecuteRemoveUser { get; private set; }
        public DelegateCommandExecutor ExecuteSaveUsers { get; private set; }
        public DelegateCommandExecutor ExecuteLoadUsers { get; private set; }

        public MainWindowViewModel()
        {
            ExecuteOpenAddUserWindow = new OpenAddUserWindowCommand(OpenAddUserWindow);
            ExecuteRemoveUser = new RemoveUserCommand(RemoveUser);
            ExecuteSaveUsers = new DelegateCommandExecutor(SaveUsers);
            ExecuteLoadUsers = new DelegateCommandExecutor(LoadUsers);
            UsersContainer.GetInstance(this);
            LoadUsers();
        }

        public void OpenAddUserWindow()
        {
            ViewFactory.CreateAddUserView();
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
            UsersContainer.OverwriteUsers(XMLUsersHandler.ReturnDeserializedUsers());
            Users = new ObservableCollection<IUser>(UsersContainer.GetUsers());
        }

        public static void UpdateUsers(List<IUser> users)
        {

        }
    }
}
