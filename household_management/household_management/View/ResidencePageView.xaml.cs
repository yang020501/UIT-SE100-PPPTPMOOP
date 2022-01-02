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
    /// Interaction logic for ResidencePageView.xaml
    /// </summary>
    public partial class ResidencePageView : Page
    {
        public ResidencePageView()
        {
            InitializeComponent();
        }

        private void dtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selected = (DataRowView)dtg.SelectedValue;
            //Expire.Text = (string)selected.Row["ExpireDate"];
            MessageBox.Show((string)selected.Row["ExpireDate"]);
        }

       
    }
}
