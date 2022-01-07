using household_management.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace household_management.ViewModel
{
    class ChartPageViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private ObservableCollection<Population> PopulationsList;
        private ObservableCollection<Household_Registration> HouseholdList;
        private ObservableCollection<Transfer_Household> TransferList;
        private ObservableCollection<Temporary_Absence> AbsenceList;
        private ObservableCollection<Temporary_Residence> ResidenceList;


        public ChartPageViewModel()
        {
            setData();
            
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<double> { PopulationsList.Count, HouseholdList.Count, TransferList.Count, AbsenceList.Count ,ResidenceList.Count}
                }
            };

            ////adding series will update and animate the chart automatically
            //SeriesCollection.Add(new ColumnSeries
            //{
            //    Title = "2016",
            //    Values = new ChartValues<double> { 11, 56, 42 }
            //});

            ////also adding values updates and animates the chart automatically
            //SeriesCollection[1].Values.Add(48d);

            Labels = new[] { "Populations", "Household", "Transfer", "Absence", "Residence" };
            Formatter = value => value.ToString("N");


        }
        private void setData()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            HouseholdList = new ObservableCollection<Household_Registration>(DataProvider.Ins.DB.Household_Registration);
            TransferList = new ObservableCollection<Transfer_Household>(DataProvider.Ins.DB.Transfer_Household);
            AbsenceList = new ObservableCollection<Temporary_Absence>(DataProvider.Ins.DB.Temporary_Absence);
            ResidenceList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
        }
    }
}