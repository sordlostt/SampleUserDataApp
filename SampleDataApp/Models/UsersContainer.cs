using SampleDataApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleDataApp.Models
{
    /// <summary>
    /// Holds a list of all the users.
    /// </summary>
    public class UsersContainer
    {

        private static UsersContainer _instance;
        private static MainWindowViewModel _mainViewModel;
        /*public static List<IUser> Users
        {
            get
            {
                if(_mainViewModel.Users == null)
                {
                    return new List<IUser> { };
                }

                return new List<IUser>(_mainViewModel.Users);
            }

            set
            {
                //workaround to notify the non-static user list in the ViewModel of change
                _mainViewModel.Users = new ObservableCollection<IUser>(value);
            }
        }*/

        private UsersContainer(MainWindowViewModel vm)
        {
            _mainViewModel = vm;
        }

        public static UsersContainer GetInstance(MainWindowViewModel vm)
        {
            if(_instance == null)
            {
                _instance = new UsersContainer(vm);
            }

            return _instance;
        }

        public static void AddUser(IUser user)
        {
            _mainViewModel.Users.Add(user);
        }

        public static void OverwriteUsers(List<IUser> users)
        {
            _mainViewModel.Users = new ObservableCollection<IUser>(users);
        }

        public static List<IUser> GetUsers()
        {
            if (_mainViewModel.Users == null)
            {
                return new List<IUser> { };
            }

            return new List<IUser>(_mainViewModel.Users);
        }
    }
}
