using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace household_management.ViewModel
{
    class TransferViewModel : BaseViewModel
    {
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name_User;
        public string Name_User { get => _Name_User; set { _Name_User = value; OnPropertyChanged(); } }
        private string _Id_User;
        public string Id_User { get => _Id_User; set { _Id_User = value; OnPropertyChanged(); } }
        private string _Id_Household;
        public string Id_Household { get => _Id_Household; set { _Id_Household = value; OnPropertyChanged(); } }
        private string _Id_Owner;
        public string Id_Owner { get => _Id_Owner; set { _Id_Owner = value; OnPropertyChanged(); } }
        private DateTime _CreateDate;
        public DateTime CreateDate { get => _CreateDate; set { _CreateDate = value; OnPropertyChanged(); } }
        private string _Old_Address;
        public string Old_Address { get => _Old_Address; set { _Old_Address = value; OnPropertyChanged(); } }
        private string _New_Address;
        public string New_Address { get => _New_Address; set { _New_Address = value; OnPropertyChanged(); } }
        private bool checkIdHousehold = false;
        public ICommand AddCommand { get; set; }
        public ICommand CheckIdHouseholdCommand { get; set; }
        public ICommand HouseholdIdChangeCommand { get; set; }
        public TransferViewModel()
        {
            HouseholdIdChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                checkIdHousehold = false;
                Old_Address = null;
            });

            CheckIdHouseholdCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if(p.Text != null)
                {
                    List<Model.Household_Registration> list_of_household = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();
                    if(list_of_household.Count() != 0)
                    {
                        foreach(Model.Household_Registration h in list_of_household)
                        {
                            if(Id_Household == h.Id)
                            {
                                MessageBox.Show("Id is valid","Notifications",MessageBoxButton.OK,MessageBoxImage.Information);
                                checkIdHousehold = true;
                                Old_Address = h.Address;
                                Id_Owner = h.IdOfOwner;
                            }
                        }

                        if(checkIdHousehold == false)
                        {
                            MessageBox.Show("Invalid id household", "Notifications", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is not any household registration","Notification!",MessageBoxButton.OK,MessageBoxImage.Warning);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Invalid id household", "Notifications", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                }
                

                
            });

            AddCommand = new RelayCommand<Button>((p) => 
            {
                if (!checkIdHousehold)
                {
                    return false;
                }

                return true; 
            }
            , (p) => 
            {
                if(Name_User == null || Id_User == null || New_Address == null)
                {
                    MessageBox.Show("There is an unfilled blank");
                }
                else if(New_Address == Old_Address)
                {
                    MessageBox.Show("The new address is the same");
                }
                else
                {
                    Model.Transfer_Household transfer_Household = new Model.Transfer_Household();
                    transfer_Household.Id = GenarateId();
                    transfer_Household.Id_Owner = Id_Owner;
                    transfer_Household.CreateDate = DateTime.Now;
                    transfer_Household.Old_Id_Household = Id_Household;
                    transfer_Household.Old_Address = Old_Address;
                    transfer_Household.New_Address = New_Address;
                    Model.DataProvider.Ins.DB.Transfer_Household.Add(transfer_Household);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    var change = Model.DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id_Household).SingleOrDefault();
                    change.Address = New_Address;
                    Model.DataProvider.Ins.DB.SaveChanges();
                    checkIdHousehold = false;

                    MessageBox.Show("Success!","Notification!",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            });

        }

        private string GenarateId()
        {
            string keychar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string keynum = "0123456789";
            Random random = new Random();
            string code = "";

            int num = random.Next(0, 26);
            code += keychar[num];

            for (int i = 0; i < 4; i++)
            {
                num = random.Next(0, 10);
                code += keynum[num];
            }

            return code;
        }
    }
}
