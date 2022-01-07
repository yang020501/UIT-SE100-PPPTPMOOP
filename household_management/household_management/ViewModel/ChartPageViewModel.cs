using household_management.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace household_management.ViewModel
{
    class ChartPageViewModel : BaseViewModel
    {
        private SeriesCollection seriesCollection;
        public SeriesCollection SeriesCollection { get => seriesCollection; set { seriesCollection = value; OnPropertyChanged(); } }
        public string[] Labels { get; set; }
        public Func<int, string> Formatter { get; set; }
        public Func<ChartPoint, string> PointLabel { get; set; }
        private ObservableCollection<Population> PopulationsList;
        private ObservableCollection<Household_Registration> HouseholdList;
        private ObservableCollection<Transfer_Household> TransferList;
        private ObservableCollection<Temporary_Absence> AbsenceList;
        private ObservableCollection<Temporary_Residence> ResidenceList;

        private SeriesCollection pieSeries;
        public SeriesCollection PieSeries { get => pieSeries; set { pieSeries = value; OnPropertyChanged(); } }

        private SeriesCollection pieSeries2;
        public SeriesCollection PieSeries2 { get => pieSeries2; set { pieSeries2 = value; OnPropertyChanged(); } }



        public ChartPageViewModel()
        {
            setData();

            pieSeries = new SeriesCollection()
            {
                new PieSeries
                {
                    Title = "None",
                    Values = new ChartValues<ObservableValue> {new ObservableValue (getCount(PopulationsList,1))},
                    DataLabels = true
                },
                 new PieSeries
                {
                    Title = "Own",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(getCount(PopulationsList, 0)) },
                    DataLabels = true
                 }
            };


            pieSeries2 = new SeriesCollection()
            {
                new PieSeries
                {
                    Title = "None",
                    Values = new ChartValues<ObservableValue> {new ObservableValue (PopulationsList.Count-HouseholdList.Count)},
                    DataLabels = true
                },
                 new PieSeries
                {
                    Title = "Owner",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(HouseholdList.Count) },
                    DataLabels = true
                 }
            };

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

            // pie chart 
            PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);



        }




        private void setData()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            HouseholdList = new ObservableCollection<Household_Registration>(DataProvider.Ins.DB.Household_Registration);
            TransferList = new ObservableCollection<Transfer_Household>(DataProvider.Ins.DB.Transfer_Household);
            AbsenceList = new ObservableCollection<Temporary_Absence>(DataProvider.Ins.DB.Temporary_Absence);
            ResidenceList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
        }
        private int getCount(ObservableCollection<Population> PopulationsList, int type)
        {

            int count = 0;
            foreach (Population item in PopulationsList)
            {
                if (item.Id_Household != null)
                {
                    count++;
                }
            }
            if (type == 0)
                return count;
            else
                return PopulationsList.Count - count;
        }
       
    }
}