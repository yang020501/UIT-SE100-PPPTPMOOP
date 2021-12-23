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
        private string _New_Id_Household;
        public string New_Id_Household { get => _New_Id_Household; set { _New_Id_Household = value; OnPropertyChanged(); } }      
        private DateTime _CreateDate;
        public DateTime CreateDate { get => _CreateDate; set { _CreateDate = value; OnPropertyChanged(); } }
        private string _Old_Address;
        public string Old_Address { get => _Old_Address; set { _Old_Address = value; OnPropertyChanged(); } }
        private string _New_Address;
        public string New_Address { get => _New_Address; set { _New_Address = value; OnPropertyChanged(); } }
        private bool checkIdHousehold = false;
        private bool checkIdHousehold_new = false;
        public ICommand AddCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand CheckIdHouseholdCommand { get; set; }
        public ICommand HouseholdIdChangeCommand { get; set; }
        public TransferViewModel()
        {
            HouseholdIdChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if(p.Name == "HouseholdIdBox")
                {
                    checkIdHousehold = false;
                    Old_Address = null;
                }
                else if(p.Name == "HouseholdIdBox_New")
                {
                    checkIdHousehold_new = false;
                    New_Address = null;
                }
            });

            ClearCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                Id_User = null;
                Name_User = null;
                Id_Household = null;
                New_Id_Household = null;
                Old_Address = null;
                New_Address = null;
                checkIdHousehold = false;
                checkIdHousehold_new = false;
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
                                
                                if(p.Name == "HouseholdIdBox")
                                {                                  
                                    Old_Address = h.Address;
                                    checkIdHousehold = true;
                                }
                                else if(p.Name == "HouseholdIdBox_New")
                                {
                                    checkIdHousehold_new = true;
                                    New_Address = h.Address;
                                }
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
                if (!checkIdHousehold || !checkIdHousehold_new)
                {
                    return false;
                }

                return true; 
            }
            , (p) => 
            {
                if(Name_User == null || Id_User == null)
                {
                    MessageBox.Show("There is an unfilled blank");
                }
                else if(Id_Household == New_Id_Household)
                {
                    MessageBox.Show("The new address is the same");
                }      
                else if (!Check_Belong_To(Id_User))
                {
                    MessageBox.Show("The user doesn't belong to household with Id: " + Id_Household);
                }
                else
                {
                    Model.Transfer_Household transfer_Household = new Model.Transfer_Household();
                    Id = GenarateId();
                    List<Model.Transfer_Household> list_of_id = Model.DataProvider.Ins.DB.Transfer_Household.ToList<Model.Transfer_Household>();
                    while (true)
                    {
                        bool isbreakable = true;
                        if (list_of_id.Count() == 0)
                        {
                            break;
                        }
                        else
                        {
                            foreach (Model.Transfer_Household d in list_of_id)
                            {
                                if (d.Id == Id)
                                {
                                    Id = GenarateId();
                                    isbreakable = false;
                                    break;
                                }
                            }
                        }

                        if (isbreakable)
                        {
                            break;
                        }
                    }
                    transfer_Household.Id = Id;
                    transfer_Household.Id_Owner = Id_User;
                    transfer_Household.CreateDate = DateTime.Now;
                    transfer_Household.Old_Id_Household = Id_Household;
                    transfer_Household.Old_Address = Old_Address;
                    transfer_Household.New_Id_Household = New_Id_Household;
                    transfer_Household.New_Address = New_Address;
                    Model.DataProvider.Ins.DB.Transfer_Household.Add(transfer_Household);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    //Đổi id household của người làm
                    var change = Model.DataProvider.Ins.DB.Populations.Where(x => x.Id == Id_User).SingleOrDefault();
                    change.Address = New_Address;
                    change.Id_Household = New_Id_Household;
                    Model.DataProvider.Ins.DB.SaveChanges();

                    //Thêm người làm vào hộ khẩu mới
                    Model.Family_Household newmember = new Model.Family_Household();
                    newmember.Id_Person = Id_User;
                    newmember.Name_Person = Name_User;
                    newmember.Id_Household = New_Id_Household;
                    newmember.Id_Owner = Model.DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == Id_Household).SingleOrDefault().IdOfOwner;
                    Model.DataProvider.Ins.DB.Family_Household.Add(newmember);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    //Xóa tên người này khỏi hộ khẩu cũ
                    var deletex = Model.DataProvider.Ins.DB.Family_Household.Where(x => x.Id_Person == Id_User).SingleOrDefault();
                    Model.DataProvider.Ins.DB.Family_Household.Remove(deletex);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    checkIdHousehold = false;
                    checkIdHousehold_new = false;

                    MessageBox.Show("Success!","Notification!",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            });

        }

        private bool Check_Belong_To(string id)
        {
            List<Model.Population> poplist = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
            if(poplist.Count() != 0)
            {
                foreach (Model.Population a in poplist)
                {
                    if(a.Id == Id_User && a.Id_Household == Id_Household)
                    {
                        return true;
                    }
                }
            }

            return false;
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
