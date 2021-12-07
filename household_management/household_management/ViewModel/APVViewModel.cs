using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace household_management.ViewModel
{
    class APVViewModel  : BaseViewModel
    {
        DataTable dt;
        
        private DataView dvAbsence;
        public DataView DvAbsence { get => dvAbsence; set { dvAbsence = value;OnPropertyChanged(); } }

        private ObservableCollection<Temporary_Absence> AbsenceList;

        public APVViewModel()
        {
            NewTableAbsence();
        }

        private void NewTableAbsence()
        {
            AbsenceList = new ObservableCollection<Temporary_Absence>(DataProvider.Ins.DB.Temporary_Absence);
            dt = new DataTable();

            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Name_HouseholdOwner");
            dt.Columns.Add("AbsenceAddress");
            dt.Columns.Add("CreateDate");
            dt.Columns.Add("ExpireDate");

            //fill datatable
            for (int i = 0; i < AbsenceList.Count; i++)
            {
                dt.Rows.Add
                    (
                       AbsenceList[i].Stt.ToString(),
                       AbsenceList[i].Id.ToString(),
                       AbsenceList[i].Id_Owner.ToString(),
                       AbsenceList[i].NameOfOwner.ToString(),
                       AbsenceList[i].Id_Household.ToString(),
                       AbsenceList[i].HouseOwnerName.ToString(),
                       AbsenceList[i].Household_Registration.Address.ToString(),
                       AbsenceList[i].CreateDate.ToString(),
                       AbsenceList[i].ExpireDate.ToString()
                    );

            }
            DvAbsence = new DataView(dt);
        }

        public void doSearch(DataGrid dtg, string find, string form)
        {
            form += " Like '%{0}%'";
            if ( DvAbsence.Count < 0) // if nothing return 
                return;
            DvAbsence.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvAbsence;
            OnPropertyChanged("DvPopulations");

        }
    }
}
