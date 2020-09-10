using SampleDataApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleDataApp.Models
{
    /// <summary>
    /// Singleton that allows other classes to modify the main view model Users data without having a direct reference to the view model.
    /// </summary>
    public class UsersContainer
    {

        private static UsersContainer _instance;
        private static MainWindowViewModel _mainViewModel;

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
