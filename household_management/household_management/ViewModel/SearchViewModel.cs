using household_management.Model;
using household_management.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace household_management.ViewModel
{
    class SearchViewModel : BaseViewModel
    {
        DataTable dt;


        DataView dvPopulations;
        public DataView DvPopulations { get => dvPopulations; set { dvPopulations = value; OnPropertyChanged(); } }

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
        
   
        private bool _rdId_Household;
        public bool rdId_Household { get => _rdId_Household; set { _rdId_Household = value; OnPropertyChanged(); } }

        private bool _rdId;
        public bool rdId { get => _rdId; set { _rdId = value; OnPropertyChanged(); } }

        private bool _rdName;
        public bool rdName { get => _rdName; set { _rdName = value; OnPropertyChanged(); } }

        private bool _rdOrdinalNumber;
        public bool rdOrdinalNumber { get => _rdOrdinalNumber; set { _rdOrdinalNumber = value; OnPropertyChanged(); } }


        PPVViewModel pPVVM = new PPVViewModel();
        APVViewModel aPVVM = new APVViewModel();

        PopulationsPageView pView = new PopulationsPageView();
        HouseholdPageView hView = new HouseholdPageView();
        TransferPageView tView = new TransferPageView();
        AbsencePageView aView = new AbsencePageView();
        ResidencePageView rView = new ResidencePageView();

        Frame main = new Frame();
        public Frame Main { get => main; set { main = value; OnPropertyChanged(); } }


        // biding txtSearch changed
        private string _txtSearch;
        public string txtSearch
        { 
            get => _txtSearch;
            set
            {
                _txtSearch = value;
                OnPropertyChanged();
                switch (SelectedIndex)
                {
                    case 0: pPVVM.doSearch(pView.dtg, _txtSearch, getrd()); break;
                    case 3: aPVVM.doSearch(aView.dtg, _txtSearch, getrd()); break;
                }
            } 
        }

        // get rdName 
        private  string getrd()
        {
            if (rdName)
                return "Name";
            else if (rdOrdinalNumber)
                return "OrdinalNumber";
            else if (rdId)
                return "Id";
            else if (rdId_Household)
                return "Id_Household";
            return "Name";
        }

        // switch tab Search
        private int _SelectedIndex;
        public int SelectedIndex 
        { 
            get => _SelectedIndex; 
            set 
            { 
                _SelectedIndex = value; OnPropertyChanged(); 
                switch(_SelectedIndex)
                {
                    case 0: openPopulationsPage(); break;
                    case 1: openHouseholdPageView(); break;
                    case 2: openTransferPageView(); break;
                    case 3: openAbsencePageView();  break;
                    case 4: openResidencePageView(); break;
                    
                }
            } 
        }

        private void openResidencePageView()
        {
            main.Content = rView;
        }
            private void openTransferPageView()
        {
            main.Content = tView;
        }

        private void openAbsencePageView()
        {
            main.Content = aView;
        }

        private void openHouseholdPageView()
        {
          
            main.Content = hView;
        }
        private void openPopulationsPage()
        {                       
            main.Content = pView;
        }

        public SearchViewModel()
        {
            //set default combox box = Populations
            SelectedIndex = 0;
            // set mode search  through Name
            rdName = true;    
        }
       

        private void NewTableResidence()
        {
            ResidencesList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
            dt = new DataTable();

            dt.Columns.Add("Ordinal Number");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name");
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

            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name");
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

            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name");
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
            dt.Columns.Add("OrdinalNumber");
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
        
    }
}
