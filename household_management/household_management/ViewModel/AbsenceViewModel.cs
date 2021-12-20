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
    class AbsenceViewModel : BaseViewModel
    {
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name_User;
        public string Name_User { get => _Name_User; set { _Name_User = value; OnPropertyChanged(); } }
        private string _Id_User;
        public string Id_User { get => _Id_User; set { _Id_User = value; OnPropertyChanged(); } }
        private string _Id_Household;
        public string Id_Household { get => _Id_Household; set { _Id_Household = value; OnPropertyChanged(); } }       
        private string _Name_Owner;
        public string Name_Owner { get => _Name_Owner; set { _Name_Owner = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private DateTime _CreateDate;
        public DateTime CreateDate { get => _CreateDate; set { _CreateDate = value; OnPropertyChanged(); } }
        private DateTime _ExpireDate;
        public DateTime ExpireDate { get => _ExpireDate; set { _ExpireDate = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand CheckIdHouseholdCommand { get; set; }
        private bool checkIdHousehold = false;
        public AbsenceViewModel()
        {
            CreateDate = DateTime.Now;
            ExpireDate = DateTime.Now;

            CheckIdHouseholdCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }
            , (p) =>
            {               
                if (p.Text != null)
                {
                    List<Model.Household_Registration> list_of_household = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();
                    if (list_of_household.Count() != 0)
                    {
                        foreach (Model.Household_Registration h in list_of_household)
                        {
                            if (Id_Household == h.Id)
                            {
                                MessageBox.Show("Id is valid", "Notifications", MessageBoxButton.OK, MessageBoxImage.Information);
                                checkIdHousehold = true;
                                Address = h.Address;
                                Name_Owner = h.NameOfOwner;
                            }
                        }
                        
                        
                     
                        if (checkIdHousehold == false)
                        {
                            MessageBox.Show("Invalid id household", "Notifications", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is not any household registration", "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);

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
                if (Name_User == null || Id_User == null)
                {
                    MessageBox.Show("There is an unfilled blank");
                }
                else if (!CheckIsDoingPopulation(Id_User))
                {
                    MessageBox.Show("The person dont have a population, please do it before doing absence certificate");
                }
                else if (ExpireDate <= CreateDate)
                {
                    MessageBox.Show("The expire date is smaller than the create date");
                    Console.WriteLine(ExpireDate);
                }
                else
                {
                    Model.Temporary_Absence license = new Model.Temporary_Absence();
                    license.Id = GenarateId();
                    license.Id_Owner = Id_User;
                    license.NameOfOwner = Name_User;
                    license.Id_Household = Id_Household;
                    license.HouseOwnerName = Name_Owner;
                    license.CreateDate = DateTime.Now;
                    license.ExpireDate = ExpireDate;

                    Model.DataProvider.Ins.DB.Temporary_Absence.Add(license);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    var person = Model.DataProvider.Ins.DB.Populations.Where(x => x.Id == Id_User).FirstOrDefault();
                    person.isAbsence = true;
                    Model.DataProvider.Ins.DB.SaveChanges();
                    checkIdHousehold = false;

                    MessageBox.Show("Add Successfully","Notification!",MessageBoxButton.OK,MessageBoxImage.Information);
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

        private bool CheckIsDoingPopulation(string Id)
        {
            List<Model.Population> list = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
            if(list.Count() != 0)
            {
                foreach(Model.Population tmp in list)
                {
                    if(tmp.Id == Id)
                    {
                        return true;
                    }
                }              
            }

            return false;
        }
    }
}
