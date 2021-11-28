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
        public Search()
        {
            InitializeComponent();
        }
        private ViewModel.SearchViewModel searchView = new ViewModel.SearchViewModel();

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
            foreach(TabItem item in tabitemlist)
            {
                if(item.IsSelected)
                {
                    doSearch((DataGrid)item.Content,getdtv(item.Name));
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
                case "tabTransfer":return searchView.DvTransfer;
                case "tabAbsence": return searchView.DvAbsence;
                case "tabResidence": return searchView.DvResidence;

            }
            return searchView.DvHousehold;

        }

        private void doSearch(DataGrid dtg,DataView dtv)
        {
            if (dtv.Count < 0)
                return;
            dtv.RowFilter = string.Format("Name Like '%{0}%'", txtSearch.Text);
            dtg.ItemsSource = dtv;
        }

        private void tabHousehold_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TabItem item = (TabItem)sender;
            TabItemFalse();
            item.IsSelected = true;
        }
    }
}
