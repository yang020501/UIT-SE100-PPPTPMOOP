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
    class APVViewModel : BaseViewModel
    {
        DataTable dt;

        private DataView dvAbsence;
        public DataView DvAbsence { get => dvAbsence; set { dvAbsence = value; OnPropertyChanged(); } }

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
                       //AbsenceList[i].Stt.ToString(),
                       //AbsenceList[i].Id.ToString(),
                       //AbsenceList[i].Id_Owner.ToString(),
                       //AbsenceList[i].NameOfOwner.ToString(),
                       //AbsenceList[i].Id_Household.ToString(),
                       //AbsenceList[i].HouseOwnerName.ToString(),
                       //AbsenceList[i].Household_Registration.Address.ToString(),
                       //AbsenceList[i].CreateDate.ToString(),
                       //AbsenceList[i].ExpireDate.ToString()
                       CheckData(AbsenceList[i])
                    ); 

            }
            DvAbsence = new DataView(dt);
        }
        // Check if any fields is null
        private string[] CheckData(Temporary_Absence item)
        {
            string[] list = new string[9];
            list[0] = check(item.Stt);
            list[1] = check(item.Id);
            list[2] = check(item.Id_Owner);
            list[3] = check(item.NameOfOwner);
            list[4] = check(item.Id_Household);
            list[5] = check(item.HouseOwnerName);
            list[6] = check(item.Household_Registration.Address);
            list[7] = check(item.CreateDate);
            list[8] = check(item.ExpireDate);
            return list;
        }
        // Convert null, string or any type to Valid view data
        private string check(object txt)
        {
            DateTime dateTime = new DateTime();
            bool gender = new bool();
            if (txt == null)
                return "";
            else if (txt.GetType() == dateTime.GetType())
            {
                dateTime = (DateTime)txt;
                return dateTime.ToString("dd/MM/yyyy");
            }
            else if (txt.GetType() == gender.GetType())
            {
                gender = (bool)txt;
                if (gender == true)
                    return "Male";
                else return "Female";
            }
            return txt.ToString();
        }


        public void doSearch(DataGrid dtg, string find, string form)
        {
            form += " Like '%{0}%'";
            if (DvAbsence.Count < 0) // if nothing return 
                return;
            DvAbsence.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvAbsence;
            OnPropertyChanged("DvPopulations");

        }
    }
}

