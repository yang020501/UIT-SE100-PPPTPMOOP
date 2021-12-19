﻿using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace household_management.ViewModel
{
    class AccountManagerViewModel : BaseViewModel
    {
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private int _Tier;
        public int Tier { get => _Tier; set { _Tier = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }
        private string _DB;
        public string DB { get => _DB; set { _DB = value; OnPropertyChanged(); } }
        private bool _Sex;
        public bool Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }
        private string _Identity;
        public string Identity { get => _Identity; set { _Identity = value; OnPropertyChanged(); } }
        private bool _MaleChoice;
        public bool MaleChoice { get => _MaleChoice; set { _MaleChoice = value; OnPropertyChanged(); } }
        private bool _FemaleChoice;
        public bool FemaleChoice { get => _FemaleChoice; set { _FemaleChoice = value; OnPropertyChanged(); } }
        public ICommand Updatebtn { get; set; }
        public ICommand Deletebtn { get; set; }

        private ObservableCollection<Model.User> UserList;

        private DataView _DvUser;
        public DataView DvUser { get => _DvUser; set { _DvUser = value; OnPropertyChanged(); } }      

        DataTable dt;

        public AccountManagerViewModel()
        {
            NewTableUser();

            Updatebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (Selected == null)
                {
                    return false;
                }

                return true;

            }, (p) =>
            {
                var change = Model.DataProvider.Ins.DB.Users.Where(x => x.Id == Id).SingleOrDefault();
                change.IdentityNum = Identity;
                change.Name = Name;
                change.Sex = MaleChoice;
                change.DateOfBirth = DateOfBirth;
                Model.DataProvider.Ins.DB.SaveChanges();

                NewTableUser();
                p.ItemsSource = DvUser;
                Selected = null;
                NullProperty();
                MessageBox.Show("Update Successful!", "Notifications!", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            });

            Deletebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (Selected != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {
                if (MessageBox.Show("Do you want to REMOVE?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Model.User remove = Model.DataProvider.Ins.DB.Users.Where(x => x.Id == Id).FirstOrDefault();
                        Model.DataProvider.Ins.DB.Users.Remove(remove);
                        Model.DataProvider.Ins.DB.SaveChanges();

                        NewTableUser();
                        p.ItemsSource = DvUser;
                        Selected = null;
                        NullProperty();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            });
        }

        private void NewTableUser()
        {
            UserList = new ObservableCollection<Model.User>(DataProvider.Ins.DB.Users);
            dt = new DataTable();

            dt.Columns.Add("Stt");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Role");
            dt.Columns.Add("IdenNum");
            dt.Columns.Add("AccountName");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Password");
            
            //fill datatablejk
            for (int i = 0; i < UserList.Count; i++)
            {
                dt.Rows.Add
                    (
                         CheckData(UserList[i])
                    );
            }
            DvUser = new DataView(dt);
        }

        private string[] CheckData(Model.User item)
        {
            string[] list = new string[8];
            list[0] = item.Id.ToString();
            list[1] = item.Username;
            list[2] = check(item.Tier);
            list[3] = check(item.IdentityNum);
            list[4] = check(item.Name);
            list[5] = check(item.DateOfBirth);
            list[6] = check(item.Sex);
            list[7] = check(item.Password);

            return list;
        }

        private string check(object txt)
        {
            DateTime dateTime = new DateTime();
            bool gender = new bool();
            int tier = new int();
            if (txt == null)
                return "";
            else if (txt.GetType() == dateTime.GetType())
            {
                dateTime = (DateTime)txt;
                return dateTime.ToString("MM/dd/yyyy");
            }
            else if (txt.GetType() == gender.GetType())
            {
                gender = (bool)txt;
                if (gender == true)
                    return "Male";
                else return "Female";
            }
            else if (txt.GetType() == tier.GetType())
            {
                tier = (int)txt;
                if(tier == 1)
                {
                    return "Manager";
                }
                else if(tier == 2)
                {
                    return "Employee";
                }
                else
                {
                    return "";
                }
            }
            return txt.ToString();
        }

        private void NullProperty()
        {         
            FemaleChoice = false;
            MaleChoice = false;
            Name = null;
            DateOfBirth = DateTime.Today;
            Id = new int();
            Username = null;
            Password = null;
            Identity = null;
            Tier = new int();
            Sex = new bool(); 
        }

        private DataRowView _Selected;
        public DataRowView Selected
        {
            get => _Selected;
            set
            {
                _Selected = value;
                OnPropertyChanged();
                if (Selected != null)
                {
                    Name = (string)Selected.Row["AccountName"];
                    Identity = (string)Selected.Row["IdenNum"];
                    if ((string)Selected.Row["Sex"] == "Male")
                    {
                        MaleChoice = true;
                        FemaleChoice = false;
                    }
                    else
                    {
                        FemaleChoice = true;
                        MaleChoice = false;
                    }
                    DB = (string)Selected.Row["DateOfBirth"];
                    Username = (string)Selected.Row["UserName"];
                    Password = "************";
                    Id = int.Parse((string)Selected.Row["Stt"]);
                    
                    //if ((string)Selected.Row["Photo"] != null && (string)Selected.Row["Photo"] != "")

                    //{
                    //    Photo = (string)Selected.Row["Photo"];
                    //    try
                    //    {
                    //        SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath("../../hinhthe/" + Photo))); // get picture
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath("../../hinhthe/" + Photo)));
                    //    }
                    //}
                    //else
                    //{
                    //    Photo = "";
                    //    SPhoto = null;
                    //}


                }
            }
        }
    }
}
