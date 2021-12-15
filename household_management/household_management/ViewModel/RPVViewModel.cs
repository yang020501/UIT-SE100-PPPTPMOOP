
﻿using household_management.Model;
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
    class RPVViewModel : BaseViewModel
    {

        DataTable dt;

        private DataView dvResidence;
        public DataView DvResidence { get => dvResidence; set { dvResidence = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        private string _IdOwner;
        public string IdOwner { get => _IdOwner; set { _IdOwner = value; OnPropertyChanged(); } }

        private string _DateOfBirth;
        public string DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }

        private string _PAddress;
        public string PAddress { get => _PAddress; set { _PAddress = value; OnPropertyChanged(); } }

        private string _TAddress;
        public string TAddress { get => _TAddress; set { _TAddress = value; OnPropertyChanged(); } }

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

        private  static ObservableCollection<Temporary_Residence> _ResidenceList;
        public ObservableCollection<Temporary_Residence> ResidenceList { get => _ResidenceList; set { _ResidenceList = value; OnPropertyChanged(); } }
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
                    PAddress = (string)Selected.Row["PAddress"];
                    TAddress = (string)Selected.Row["TAddress"];
                    CreateDate = (string)Selected.Row["CreateDate"];
                    ExpireDate = (string)Selected.Row["ExpireDate"];
                    HName = (string)Selected.Row["Name_HouseholdOwner"];
                    Id_Household = (string)Selected.Row["Id_Household"];
                    if ((string)Selected.Row["Gender"] == "Male")
                        MaleChoice = true;
                    else
                        FemaleChoice = true;
                }
            }
        }

        public RPVViewModel()
        {
            NewTableResidence();
            Deletebtn = new RelayCommand<object>((p) =>
            {
                if (Selected != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {

                DataProvider.Ins.DB.Temporary_Residence.Remove(DataProvider.Ins.DB.Temporary_Residence.Where(x => x.Id == Id).SingleOrDefault());
                DataProvider.Ins.DB.SaveChanges();
                NewTableResidence();

            });
        }

        private void NewTableResidence()
        {
            ResidenceList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
            dt = new DataTable();

            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Id_Owner");
            dt.Columns.Add("Name");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Name_HouseholdOwner");
            dt.Columns.Add("PAddress");
            dt.Columns.Add("CreateDate");
            dt.Columns.Add("ExpireDate");
            dt.Columns.Add("Gender");
            dt.Columns.Add("TAddress");
            //fill datatable
            for (int i = 0; i < ResidenceList.Count; i++)
            {

                dt.Rows.Add
                    (                     
                       CheckData(ResidenceList[i],i)
                    );

            }
            DvResidence = new DataView(dt);
        }
        // Check if any fields is null
        private string[] CheckData(Temporary_Residence item,int stt)
        {
            string[] list = new string[11];
            list[0] = (stt+1).ToString();
            list[1] = check(item.Id);
            list[2] = check(item.Id_Owner);
            list[3] = check(item.NameOfOwner);
            list[4] = check(item.Id_Household);
            list[5] = check(item.HouseOwnerName);
            list[6] = check(item.PAddress);
            list[7] = check(item.CreateDate);
            list[8] = check(item.ExpireDate);
            var link = DataProvider.Ins.DB.Populations.Where(x => x.Id == item.Id_Owner).SingleOrDefault();
            if (link != null)
                list[9] = check(link.Sex);
            else list[9] = "";
            list[10] = check(item.TAddress);
            return list;
        }
        public void Load()
        {
            NewTableResidence();
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
            if (DvResidence.Count < 0) // if nothing return 
                return;
            DvResidence.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvResidence;
            OnPropertyChanged();

        }
    }
}
