using household_management.Model;
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

        private void dtg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selected = (DataRowView)dtg.SelectedValue;
            txtName.Text = (string)selected.Row["Name"];
            txtId.Text = (string)selected.Row["Id"];
            txtHId.Text = (string)selected.Row["Id_Household"];
            txtAddress.Text = (string)selected.Row["Address"];
            txtPBirth.Text = (string)selected.Row["PlaceOfBirth"];
            dpBirth.Text = (string)selected.Row["DateOfBirth"];
            txtCareer.Text = (string)selected.Row["Career"];
            txtRelegion.Text = (string)selected.Row["Relegion"];
            if ((string)selected.Row["Gender"] == "Male")
                MaleChoise.IsChecked = true;
            else
                FemaleChoise.IsChecked = true;
            MessageBox.Show((string)selected.Row["Name"]);
            
        }

    }
}
