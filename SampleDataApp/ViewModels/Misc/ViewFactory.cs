using SampleDataApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDataApp.ViewModels.Misc
{
    public static class ViewFactory
    {
        public static void CreateAddUserView()
        {
            AddUserWindowView addUserWindow = new AddUserWindowView();
            addUserWindow.Show();
        }
    }
}
