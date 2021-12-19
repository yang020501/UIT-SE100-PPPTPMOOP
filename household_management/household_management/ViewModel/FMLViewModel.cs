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
    class FMLViewModel : BaseViewModel
    {
        DataTable dt;

        private DataView dvFamily;
        public DataView DvFamily { get => dvFamily; set { dvFamily = value; OnPropertyChanged(); } }

        private ObservableCollection<Family_Household> FamilyList;
        public ICommand Exitbtn { get; set; }
        public ICommand Addbtn { get; set; }


        public FMLViewModel()
        {
            NewTableFamily();
        }
        public void Load(string Id)
        {
            NewTableFamily(Id);
        }
        private void NewTableFamily(string Id = "")
        {
            FamilyList = new ObservableCollection<Family_Household>(DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Household == Id));
            dt = new DataTable();

            dt.Columns.Add("Id_Person");
            dt.Columns.Add("Name_Person");

            Exitbtn = new RelayCommand<Window>(
                (p) =>
                {
                    return true;
                },
                (p) =>
                {
                    p.DataContext = null;
                    p.Close();
                }
                );

            //fill datatable
            for (int i = 0; i < FamilyList.Count; i++)
            {

                dt.Rows.Add
                    (
                       CheckData2(FamilyList[i], i)
                    );

            }
            dvFamily = new DataView(dt);
        }
        private string[] CheckData2(Family_Household item, int stt)
        {

            string[] list = new string[2];
            list[0] = check(item.Id_Person);
            list[1] = check(item.Name_Person);

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
    }
}
