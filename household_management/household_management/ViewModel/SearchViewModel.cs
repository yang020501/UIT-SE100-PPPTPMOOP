﻿using household_management.Model;
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
        RPVViewModel rPVVM = new RPVViewModel();
        TPVViewModel tPVVM = new TPVViewModel();    

        PopulationsPageView pView = new PopulationsPageView() ;
        HouseholdPageView hView  = new HouseholdPageView() ;
        TransferPageView tView = new TransferPageView();
        AbsencePageView aView = new AbsencePageView() ;
        ResidencePageView rView = new ResidencePageView() ;

        private Frame main = new Frame();
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
                    case 1:
                    case 2: tPVVM.doSearch(tView.dtg, _txtSearch, getrd()); break;
                    case 3: aPVVM.doSearch(aView.dtg, _txtSearch, getrd()); break;
                    case 4: rPVVM.doSearch(rView.dtg, _txtSearch, getrd()); break;

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
        // reload + view
        private void openResidencePageView()
        {
            main.Refresh();
            rView.DataContext = null;
            RPVViewModel vm = new RPVViewModel();
            vm.Load();
            rView.DataContext = vm;
            main.Content = rView;
        }
            private void openTransferPageView()
        {
            main.Refresh();
            tView = new TransferPageView();
            main.Content = tView;
        }

        private void openAbsencePageView()
        {
            main.Refresh();
            aView = new AbsencePageView();
            main.Content = aView;
        }

        private void openHouseholdPageView()
        {
            main.Refresh();
            hView = new HouseholdPageView();
            main.Content = hView;
        }
        private void openPopulationsPage()
        {
            main.Refresh();
            pView = new PopulationsPageView();
            main.Content = pView;
        }

        public SearchViewModel()
        {
            
            // set mode search  through Name
            rdName = true;    
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
