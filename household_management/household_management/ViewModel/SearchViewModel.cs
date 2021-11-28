using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace household_management.ViewModel
{
    class SearchViewModel : BaseViewModel
    {
        DataTable dt;
        DataView dvPopulations;
        public DataView DvPopulations { get => dvPopulations; set => dvPopulations = value; }
        DataView dvHousehold;
        public DataView DvHousehold { get => dvHousehold; set => dvHousehold = value; }

        private ObservableCollection<Population> _PopulationsList;
        public ObservableCollection<Population> PopulationsList { get => _PopulationsList; set { _PopulationsList = value; OnPropertyChanged(); } }
        private ObservableCollection<Household_Registration> _HouseholdList;
        public ObservableCollection<Household_Registration> HouseholdList { get => _HouseholdList; set { _HouseholdList = value; OnPropertyChanged(); } }

        public SearchViewModel()
        {
            NewTablePopulations();
            NewTableHousehold();         

            
        }

        private void NewTableHousehold()
        {
            HouseholdList = new ObservableCollection<Household_Registration>(DataProvider.Ins.DB.Household_Registration);
            dt = new DataTable();
            dt.Columns.Add("Stt");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");

            for (int i = 0; i < HouseholdList.Count; i++)
            {
                dt.Rows.Add
                    (
                        HouseholdList[i].Stt.ToString(),
                        HouseholdList[i].Id.ToString(),
                        HouseholdList[i].IdOfOwner.ToString(),
                        HouseholdList[i].NameOfOwner.ToString(),
                        HouseholdList[i].Address.ToString()

                    );
                ;
            }
            dvHousehold = new DataView(dt);

        }

        private void NewTablePopulations()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            dt = new DataTable();
            dt.Columns.Add("Stt");
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("PlaceOfBirth");
            dt.Columns.Add("Address");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Religion");
            dt.Columns.Add("Career");
            //fill datatable
            for (int i = 0; i < PopulationsList.Count; i++)
            {
                dt.Rows.Add
                    (
                         PopulationsList[i].Stt.ToString(),
                         PopulationsList[i].Id.ToString(),
                         PopulationsList[i].Name.ToString(),
                         PopulationsList[i].PlaceOfBirth.ToString(),
                         PopulationsList[i].DateOfBirth.ToString(),
                         PopulationsList[i].Sex.ToString(),
                         PopulationsList[i].Relegion.ToString(),
                         PopulationsList[i].Career.ToString()
                    );
            }
            dvPopulations = new DataView(dt);
        }


        private void populateListView(DataView dv)
        {
            
        }

        
    }
}
