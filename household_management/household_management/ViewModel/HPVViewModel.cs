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
using System.Windows.Input;

namespace household_management.ViewModel
{
    class HPVViewModel : BaseViewModel
    {

        DataTable dt;

        private DataView dvHousehold;
        public DataView DvHousehold { get => dvHousehold; set { dvHousehold = value; OnPropertyChanged(); } }
       

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }


        private string _Id_Owner;
        public string Id_Owner { get => _Id_Owner; set { _Id_Owner = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _HAddress;
        public string HAddress { get => _HAddress; set { _HAddress = value; OnPropertyChanged(); } }

        private bool _MaleChoice;
        public bool MaleChoice { get => _MaleChoice; set { _MaleChoice = value; OnPropertyChanged(); } }
        private bool _FemaleChoice;
        public bool FemaleChoice { get => _FemaleChoice; set { _FemaleChoice = value; OnPropertyChanged(); } }

        
        private ObservableCollection<Household_Registration> HouseholdList;

        private ObservableCollection<Family_Household> FamilyList;


        public ICommand Updatebtn { get; set; }
        public ICommand Deletebtn { get; set; }
        public ICommand Viewbtn { get; set; }

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
                    if ((string)Selected.Row["Gender"] == "Male")
                    {
                        MaleChoice = true;
                        FemaleChoice = false;
                    }
                    else
                    {
                        FemaleChoice = true;
                        MaleChoice = false;
                    }

                    Name = (string)Selected.Row["Name"];
                    Id = (string)Selected.Row["Id_Household"];
                    Id_Owner = (string)Selected.Row["Id"];
                    Address = (string)Selected.Row["Address"];
                    HAddress = (string)Selected.Row["HAddress"];
                    FamilyList = new ObservableCollection<Family_Household>(DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Household == Id));




    }
            }
        }
        public HPVViewModel()
        {
            NewTableHousehold();
            //Update
            Updatebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id);

                if (displayList == null)
                    return false;
                return true;

            }, (p) =>
            {
                var tmp = DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id).SingleOrDefault();
                try
                {

                    tmp.Address = HAddress;

                    DataProvider.Ins.DB.SaveChanges();
                    //reload 
                    Selected = null;
                    NullProperty();
                    NewTableHousehold();
                    p.ItemsSource = dvHousehold;
                    MessageBox.Show("Update Successfully!", "Notifications!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }               
  
            });
            //Delete
            Deletebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (Selected != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {

                if (MessageBox.Show("Do you want to REMOVE?"+"\nAll relevant FamilyMember in Household will be REMOVE", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {                   
                    //try
                    //{
                        if (FamilyList != null)
                        {
                            foreach (Family_Household item in FamilyList)
                            {
                                DataProvider.Ins.DB.Family_Household.Remove(item);
                            }
                        }

                        DataProvider.Ins.DB.Household_Registration.Remove(DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id).SingleOrDefault());

                        DataProvider.Ins.DB.SaveChanges();

                        // reload view table
                        Selected = null;
                        NullProperty();
                        NewTableHousehold();
                        p.ItemsSource = DvHousehold; ;
                    //}                                             
                    //catch (Exception e)
                    //{
                        //MessageBox.Show(e.Message, "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //}
                   
                }
            });
            Viewbtn = new RelayCommand<object>(
                (p) =>
                {
                    if (Selected == null)
                        return false;
                    return true;
                }, 
                (p) =>
                 {
                     FamilyList wd = new FamilyList();
                     wd.DataContext = null;
                     FMLViewModel vm = new FMLViewModel();
                     vm.Load(Id);
                     wd.DataContext = vm;
                     wd.ShowDialog();
                 }
                );
                   
        }

        private void NullProperty()
        {

            FemaleChoice = false;
            MaleChoice = false;
            Name = null;
            Id = null;
            Id_Owner = null;
            Address = null;
            HAddress = null;
            Selected = null;

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
            dt.Columns.Add("HAddress");
            dt.Columns.Add("Gender");

            //fill datatable
            for (int i = 0; i < HouseholdList.Count; i++)
            {

                dt.Rows.Add
                    (
                       CheckData(HouseholdList[i], i)
                    );

            }
            DvHousehold = new DataView(dt);
        }
        // Check if any fields is null
        private string[] CheckData(Household_Registration item, int stt)
        {
            var link = DataProvider.Ins.DB.Populations.Where(x => x.Id == item.IdOfOwner).SingleOrDefault();
            string[] list = new string[7];
            list[0] = (stt + 1).ToString();
            list[1] = check(item.Id);           
            list[2] = check(item.IdOfOwner);
            if (link != null)
                list[3] = check(link.Name);
            else list[3] = check(item.NameOfOwner);
            if (link != null)
                list[4] = check(link.Address);
            else list[4] = "";
            list[5] = check(item.Address);
            if (link != null)
                list[6] = check(link.Sex);
            else list[6] = "";
            
            return list;
        }
        public void Load()
        {
            NewTableHousehold();
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
            if (DvHousehold.Count < 0) // if nothing return 
                return;
            DvHousehold.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvHousehold;
            OnPropertyChanged();

        }

    }
}
