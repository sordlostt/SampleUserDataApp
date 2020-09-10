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
using System.Collections.Specialized;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;

namespace SampleDataApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<IUser> _users;
        private bool _areButtonsEnabled = false;
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
        // this is set to true by any action that modifies the data
        public bool AreButtonsEnabled
        {
            get
            {
                return _areButtonsEnabled;
            }

            set
            {
                _areButtonsEnabled = value;
                OnPropertyChanged("AreButtonsEnabled");
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
            RegisterMessengerNotifications();
        }

        public void OpenAddUserWindow()
        {
            ViewFactory.CreateAddUserView();
            AddUserWindowViewModel.CanOpen = false;
        }

        public void RemoveUser(IUser user)
        {
            if (Users.Count > 0)
            {
                Users.Remove(user);
                Messenger.Default.Send(new NotificationMessage("EnableButtons"));
            }
        }

        public void SaveUsers()
        {
            XMLDataSerializer.SerializeUsers(new XMLUsers());
            XMLFileManager.SaveFile();
            Messenger.Default.Send(new NotificationMessage("DisableButtons"));
        }

        public void LoadUsers()
        {
            UsersContainer.OverwriteUsers(XMLUsersHandler.ReturnDeserializedUsers());
            Users = new ObservableCollection<IUser>(UsersContainer.GetUsers());
            Messenger.Default.Send(new NotificationMessage("DisableButtons"));
        }

        private void RegisterMessengerNotifications()
        {
            Messenger.Default.Register<NotificationMessage>(this, m =>
            {
                if (m.Notification == "EnableButtons")
                {
                    AreButtonsEnabled = true;
                }

                if (m.Notification == "DisableButtons")
                {
                    AreButtonsEnabled = false;
                }
            });
        }

    }
}
