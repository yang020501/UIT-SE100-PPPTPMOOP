using household_management.Model;
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
    class FMLViewModel : BaseViewModel
    {
        DataTable dt;

        private DataView dvFamily;
        public DataView DvFamily { get => dvFamily; set { dvFamily = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        private  string _Id_Household;
        public string Id_Household { get => _Id_Household; set { _Id_Household = value;OnPropertyChanged(); } }

        private ObservableCollection<Family_Household> FamilyList;
        public ICommand Exitbtn { get; set; }
        public ICommand Addbtn { get; set; }
        public ICommand Deletebtn { get; set; }

        private DataRowView _Selected;
        public DataRowView Selected 
        { 
            get => _Selected; 
            set 
            {
                _Selected = value;
                OnPropertyChanged();
            } 
        }
        public FMLViewModel()
        {
            Id = "";
            NewTableFamily();
            //close window
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
            // Remove
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
                    string tmp = (string)Selected.Row["Id_Person"];
                    var familymemList = DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Person == tmp).ToList();
                    if (familymemList != null)
                    {
                        Family_Household familymem = new Family_Household();
                        if (familymemList.Count > 1)
                        {
                            foreach (Family_Household item in familymemList)
                            {
                                if (item.Id_Household == Id_Household)
                                {
                                    familymem = item;
                                    break;
                                }
                            }
                        }
                        else familymem = DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Person == tmp).SingleOrDefault();
                        if (familymem.Id_Owner == familymem.Id_Person)
                        {
                            MessageBox.Show("You can't REMOVE Household_Owner", "Notification!", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        DataProvider.Ins.DB.Family_Household.Remove(familymem);
                    }

                    //Upadte Id_household in popualtions
                    Population pPerson = DataProvider.Ins.DB.Populations.Where(x => x.Id == tmp).SingleOrDefault();
                    pPerson.Id_Household = null;

                    DataProvider.Ins.DB.SaveChanges();


                    //reload
                    Selected = null;
                    NewTableFamily(Id_Household);
                    p.ItemsSource = dvFamily;

                }
            }
            );
            // Add member
            Addbtn = new RelayCommand<DataGrid>((p) =>
            {
                if (Id != null && Id != "")
                {
                    if (Id.Length == 12)
                    {
                        foreach (Family_Household tmp in FamilyList)
                        {
                            if (tmp.Id_Person == Id)
                                return false;
                        }
                        long result;
                        if (!long.TryParse(Id, out result))
                            return false;
                        Population person = DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault();
                        if (person == null)
                        {
                          
                            Id = "";
                           
                            MessageBox.Show("This person has not declared his/her identity!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }
                        else if (person.Id_Household != null)
                        {
                            Id = "";
                            
                            MessageBox.Show("This person has declared Household Registration!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }

                        return true;
                    }
                }
                return false;
            }, (p) =>
            {
                Population pPerson = DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault();
                Household_Registration oPerson = DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id_Household).SingleOrDefault();
                Family_Household person = new Family_Household();


                person.Id_Household = Id_Household;
                if (oPerson != null)
                    person.Id_Owner = oPerson.IdOfOwner;
                else
                    person.Id_Owner = "";
                person.Id_Person = Id;
                if (pPerson != null)
                    person.Name_Person = pPerson.Name;
                else
                    person.Name_Person = "";
                //Upadte Id_household in popualtions
                pPerson.Id_Household = Id_Household;
                try
                {
                    
                   
                    DataProvider.Ins.DB.Family_Household.Add(person);
                    DataProvider.Ins.DB.SaveChanges();
                    Selected = null;
                    NewTableFamily(Id_Household);
                    p.ItemsSource = dvFamily;
                    MessageBox.Show("Add Successfully!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception e)
                {
                    MessageBox.Show("Fail!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Error);
                }



        });

        }
        public void Load(string Id_Household)
        {
            this.Id_Household = Id_Household;
            NewTableFamily( Id_Household);
        }
        private void NewTableFamily(string Id_Household = "")
        {
            Id = "";
            FamilyList = new ObservableCollection<Family_Household>(DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Household == Id_Household));
            dt = new DataTable();

            dt.Columns.Add("Id_Person");
            dt.Columns.Add("Name_Person");
          
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
