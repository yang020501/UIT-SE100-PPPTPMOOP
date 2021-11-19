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

<<<<<<< HEAD
<<<<<<< HEAD
        private void btnPopualtion_Click(object sender, RoutedEventArgs e)
        {
            Populations wd = new Populations();
            wd.ShowDialog();
        }
=======
>>>>>>> 834df12c97f21da48e3fdb6394d7e5371a2a12f1
=======
>>>>>>> 834df12c97f21da48e3fdb6394d7e5371a2a12f1
    }
}
