using household_management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace household_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void btnPopualtion_Click(object sender, RoutedEventArgs e)
        {
            Populations wd = new Populations();
            wd.ShowDialog();
        }

        private void btnHousehold_Click(object sender, RoutedEventArgs e)
        {
            Household wd = new Household();
            wd.ShowDialog();
        }

        private void btnAbsence_Click(object sender, RoutedEventArgs e)
        {
            Absence wd = new Absence();
            wd.ShowDialog();
        }

        private void btnResidence_Click(object sender, RoutedEventArgs e)
        {
            Residence wd = new Residence();
            wd.ShowDialog();
        }
    }
}
