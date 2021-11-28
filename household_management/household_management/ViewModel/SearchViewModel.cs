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
        public DataView DvPopulations { get => dvPopulations; set { dvPopulations = value; OnPropertyChanged(); }}

        DataView dvHousehold;
        public DataView DvHousehold { get => dvHousehold; set { dvHousehold = value; OnPropertyChanged(); } }

        DataView dvTransfer;
        public DataView DvTransfer { get => dvTransfer; set { dvTransfer = value; OnPropertyChanged(); } }

        DataView dvAbsence;
        public DataView DvAbsence { get => dvAbsence; set { dvAbsence = value; OnPropertyChanged(); } }

        DataView dvResidence;
        public DataView DvResidence { get => dvResidence; set { dvResidence = value; OnPropertyChanged(); } }


        private ObservableCollection<Population> _PopulationsList;
        public ObservableCollection<Population> PopulationsList { get => _PopulationsList; set { _PopulationsList = value; OnPropertyChanged(); } }

        private ObservableCollection<Household_Registration> _HouseholdList;
        public ObservableCollection<Household_Registration> HouseholdList { get => _HouseholdList; set { _HouseholdList = value; OnPropertyChanged(); } }
                
        private ObservableCollection<Transfer_Household> _TransferList;
        public ObservableCollection<Transfer_Household> TransferList { get => _TransferList; set { _TransferList = value; OnPropertyChanged(); } }

        private ObservableCollection<Temporary_Absence> _AbsencesList;
        public ObservableCollection<Temporary_Absence> AbsencesList { get => _AbsencesList; set { _AbsencesList = value; OnPropertyChanged(); } }
               
        private ObservableCollection<Temporary_Residence> _ResidencesList;
        public ObservableCollection<Temporary_Residence> ResidencesList { get => _ResidencesList; set { _ResidencesList = value; OnPropertyChanged(); } }

   
        public SearchViewModel()
        {
            NewTableHousehold();
            NewTablePopulations();
            NewTableTransfer();
            NewTableAbsence();
            NewTableResidence();
        }

        private void NewTableResidence()
        {
            ResidencesList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
            dt = new DataTable();

            dt.Columns.Add("Ordinal Number");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name Owner");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Name_HouseholdOwner");
            dt.Columns.Add("Absence Address");
            dt.Columns.Add("Residence Address");
            dt.Columns.Add("Create Date");
            dt.Columns.Add("Expire Date");

            for (int i = 0; i < ResidencesList.Count; i++)
            {
                dt.Rows.Add
                    (
                       ResidencesList[i].Stt.ToString(),
                       ResidencesList[i].Id.ToString(),
                       ResidencesList[i].Id_Owner.ToString(),
                       ResidencesList[i].NameOfOwner.ToString(),
                       ResidencesList[i].Id_Household.ToString(),
                       ResidencesList[i].HouseOwnerName.ToString(),
                       ResidencesList[i].PAddress.ToString(),
                       ResidencesList[i].TAddress.ToString(),
                       ResidencesList[i].CreateDate.ToString(),
                       ResidencesList[i].ExpireDate.ToString()
                    );

            }
            dvResidence = new DataView(dt);
        }

        private void NewTableAbsence()
        {
            AbsencesList = new ObservableCollection<Temporary_Absence>(DataProvider.Ins.DB.Temporary_Absence);
            dt = new DataTable();

            dt.Columns.Add("Ordinal Number");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name Owner");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Name_HouseholdOwner");
            dt.Columns.Add("Absence Address");
            dt.Columns.Add("Create Date");
            dt.Columns.Add("Expire Date");

            //fill datatable
            for (int i = 0; i <AbsencesList.Count; i++)
            {
                dt.Rows.Add
                    (
                       AbsencesList[i].Stt.ToString(),
                       AbsencesList[i].Id.ToString(),
                       AbsencesList[i].Id_Owner.ToString(),
                       AbsencesList[i].NameOfOwner.ToString(),
                       AbsencesList[i].Id_Household.ToString(),
                       AbsencesList[i].HouseOwnerName.ToString(),
                       AbsencesList[i].Household_Registration.Address.ToString(),
                       AbsencesList[i].CreateDate.ToString(),
                       AbsencesList[i].ExpireDate.ToString()
                    );
                
            }
            dvAbsence = new DataView(dt);
        }

        private void NewTableTransfer()
        {
            TransferList = new ObservableCollection<Transfer_Household>(DataProvider.Ins.DB.Transfer_Household);
            dt = new DataTable();

            dt.Columns.Add("Ordinal Number");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name Owner");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Old Address");
            dt.Columns.Add("New Address");
            //fill datatable
            for (int i = 0; i < TransferList.Count; i++)
            {
                dt.Rows.Add
                    (
                        TransferList[i].Stt.ToString(),
                        TransferList[i].Id.ToString(),
                        TransferList[i].Id_Owner.ToString(),
                        TransferList[i].Population.Name.ToString(),
                        TransferList[i].Old_Address.ToString(),
                        TransferList[i].New_Address.ToString()
                    ); 
                ;
            }
            dvTransfer = new DataView(dt);
        }

        private void NewTableHousehold()
        {
            HouseholdList = new ObservableCollection<Household_Registration>(DataProvider.Ins.DB.Household_Registration);
            dt = new DataTable();
            dt.Columns.Add("Ordinal Number");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            //fill datatable
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
            //add View
            dvHousehold = new DataView(dt);

        }

        private void NewTablePopulations()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            dt = new DataTable();
            dt.Columns.Add("Ordinal Number");
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
