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
using System.Windows.Shapes;

namespace household_management.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private ViewModel.SearchViewModel searchView = new ViewModel.SearchViewModel();
        List<RadioButton> radioButtons = new List<RadioButton>();
        public Search()
        {
            InitializeComponent();
            txtSearch.Focus();
            AddRadio();
        }

        private void AddRadio()
        {
            radioButtons.Add(rdName);
            radioButtons.Add(rdId);
            radioButtons.Add(rdOrdinalNumber);
            radioButtons.Add(rdId_Household);
        }

        private void TabItemFalse()
        {
            tabHousehold.IsSelected = false;
            tabAbsence.IsSelected = false;
            tabPopulation.IsSelected = false;
            tabResidence.IsSelected = false;
            tabTransfer.IsSelected = false;
        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
           
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ItemCollection tabitemlist = tablist.Items;
            foreach (TabItem item in tabitemlist)
            {
                if (item.IsSelected)
                {
                    doSearch((DataGrid)item.Content, getdtv(item.Name));
                    break;
                }
            }


        }

        private DataView getdtv(string name)
        {

            switch (name)
            {
                case "tabHousehold": return searchView.DvHousehold;
                case "tabPopulation": return searchView.DvPopulations;
                case "tabTransfer": return searchView.DvTransfer;
                case "tabAbsence": return searchView.DvAbsence;
                case "tabResidence": return searchView.DvResidence;

            }
            return searchView.DvHousehold;

        }

        private void doSearch(DataGrid dtg, DataView dtv)
        {
            string form="";
            if (dtv.Count < 0)
                return;
            foreach (RadioButton item in radioButtons)
            {
                if((bool)item.IsChecked)
                {
                    form += item.Name.Substring(2) + " Like  '%{0}%'";
                }
            }
            dtv.RowFilter = string.Format(form, txtSearch.Text);
            dtg.ItemsSource = dtv;
        }

        private void tabHousehold_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TabItem item = (TabItem)sender;
            TabItemFalse();
            item.IsSelected = true;
            txtSearch.Focus();
        }
    }
}
