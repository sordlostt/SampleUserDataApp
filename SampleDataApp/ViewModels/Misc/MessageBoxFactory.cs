using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SampleDataApp.ViewModels.Misc
{
    public static class MessageBoxFactory
    {
        public static void DisplayWrongDateFormatMessage()
        {
            MessageBox.Show("Please fill the birthday field correctly.");
        }

        public static void DisplayFormNotFilledMessage()
        {
            MessageBox.Show("Please fill all requested fields.");
        }
    }
}
