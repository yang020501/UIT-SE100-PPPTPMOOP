using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace household_management.ViewModel
{
    class TPVViewModel :BaseViewModel
    {
        DataTable dt;

        private DataView dvTransfer;
        public DataView DvTransfer { get => dvTransfer; set { dvTransfer = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        private string _IdOwner;
        public string IdOwner { get => _IdOwner; set { _IdOwner = value; OnPropertyChanged(); } }

        private string _DateOfBirth;
        public string DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }

        private string _OAddress;
        public string OAddress { get => _OAddress; set { _OAddress = value; OnPropertyChanged(); } }

        private string _NAddress;
        public string NAddress { get => _NAddress; set { _NAddress = value; OnPropertyChanged(); } }

        private string _HName;
        public string HName { get => _HName; set { _HName = value; OnPropertyChanged(); } }

        private string _Id_Household;
        public string Id_Household { get => _Id_Household; set { _Id_Household = value; OnPropertyChanged(); } }

        private string _CreateDate;
        public string CreateDate { get => _CreateDate; set { _CreateDate = value; OnPropertyChanged(); } }

        private string _ExpireDate;
        public string ExpireDate { get => _ExpireDate; set { _ExpireDate = value; OnPropertyChanged(); } }

        private bool _MaleChoice;
        public bool MaleChoice { get => _MaleChoice; set { _MaleChoice = value; OnPropertyChanged(); } }
        private bool _FemaleChoice;
        public bool FemaleChoice { get => _FemaleChoice; set { _FemaleChoice = value; OnPropertyChanged(); } }

        private ObservableCollection<Transfer_Household> TransferList;
        public ICommand Deletebtn { get; set; }

        private DataRowView _Selected;
        public DataRowView Selected
        {
            get => _Selected;
            set
            {
                _Selected = value;
                OnPropertyChanged();
                if (_Selected != null)
                {
                    Name = (string)Selected.Row["Name"];
                    IdOwner = (string)Selected.Row["Id_Owner"];
                    Id = (string)Selected.Row["Id"];
                    OAddress = (string)Selected.Row["OldAddress"];
                    NAddress = (string)Selected.Row["NewAddress"];
                    CreateDate = (string)Selected.Row["CreateDate"];
                    HName = (string)Selected.Row["Name_HouseholdOwner"];
                    Id_Household = (string)Selected.Row["Id_Household"];
                    if ((string)Selected.Row["Gender"] == "Male")
                        MaleChoice = true;
                    else
                        FemaleChoice = true;
                }
            }
        }

        public TPVViewModel()
        {
            NewTableTransfer();
            Deletebtn = new RelayCommand<object>((p) =>
            {
                if (Selected != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {

                DataProvider.Ins.DB.Transfer_Household.Remove(DataProvider.Ins.DB.Transfer_Household.Where(x => x.Id == Id).SingleOrDefault());
                DataProvider.Ins.DB.SaveChanges();
                NewTableTransfer();

            });
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
            dt.Columns.Add("Name_HouseholdOwner");
            dt.Columns.Add("OldAddress");
            dt.Columns.Add("CreateDate");
            dt.Columns.Add("Gender");
            dt.Columns.Add("NewAddress");
            //fill datatable
            for (int i = 0; i < TransferList.Count; i++)
            {

                dt.Rows.Add
                    (
                       
                       CheckData(TransferList[i],i)
                    );

            }
            DvTransfer = new DataView(dt);
        }
        // Check if any fields is null
        private string[] CheckData(Transfer_Household item,int stt)
        {
            string[] list = new string[10];
            list[0] = (stt + 1).ToString();
            list[1] = check(item.Id);
            list[2] = check(item.Id_Owner);
            list[3] = check(item.Population.Name);
            list[4] = check(item.Old_Id_Household);
            var link = DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == item.Old_Id_Household).SingleOrDefault();
            if (link != null)
                list[5] = check(link.NameOfOwner);
            else 
                list[5] = "";
            list[6] = check(item.Old_Address);
            list[7] = check(item.CreateDate);
            var link2 = DataProvider.Ins.DB.Populations.Where(x => x.Id == item.Id_Owner).SingleOrDefault();
            if (link2 != null)
                list[8] = check(link2.Sex);
            else list[8] = "";
            list[9] = check(item.New_Address);
            return list;
        }
        public void Load()
        {
            NewTableTransfer();
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
            if (DvTransfer.Count < 0) // if nothing return 
                return;
            DvTransfer.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvTransfer;
            OnPropertyChanged();

        }
    }
}
