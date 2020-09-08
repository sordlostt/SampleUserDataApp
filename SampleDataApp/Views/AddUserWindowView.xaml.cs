using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SampleDataApp.Models;
using SampleDataApp.ViewModels;

namespace SampleDataApp.Views
{
    /// <summary>
    /// Interaction logic for AddUserWindowView.xaml
    /// </summary>
    public partial class AddUserWindowView : Window
    {
        public AddUserWindowView()
        {
            InitializeComponent();

            AddUserWindowViewModel viewModel = new AddUserWindowViewModel();
            DataContext = viewModel;
        }
    }
}
