using household_management.Model;
using household_management.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace household_management.View
{
    /// <summary>
    /// Interaction logic for PopulationsPageView.xaml
    /// </summary>
    public partial class PopulationsPageView : Page
    {
        public PopulationsPageView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
           
        }

  

        
    }
}
