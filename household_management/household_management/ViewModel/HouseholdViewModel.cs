using household_management.View;
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
    class HouseholdViewModel : BaseViewModel
    {        
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _IdHousehold;
        public string IdHousehold { get => _IdHousehold; set { _IdHousehold = value; OnPropertyChanged(); } }
        private string _IdMembers;
        public string IdMembers { get => _IdMembers; set { _IdMembers = value; OnPropertyChanged(); } }
        public static string Id_Family;
        public ICommand btnClear { get; set; }
        public ICommand btnAdd { get; set; }
        public ICommand btnFamily { get; set; }
        public ICommand HouseholdAddressChangeCommand { get; set; }
        public ICommand ReloadCommand { get; set; }
        public ICommand HouseholdIdChangeCommand { get; set; }

        public static string current_IdHousehold;
        public static string current_Address_Household;
        public static string current_IdOwner;       
        public HouseholdViewModel()
        {
            IdHousehold = GenarateId();
            Console.WriteLine(IdHousehold);
            List<Model.Household_Registration> list_of_h = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();
            while (true)
            {
                bool isbreakable = true;
                if(list_of_h.Count() == 0)
                {
                    break;
                }
                else
                {
                    foreach(Model.Household_Registration d in list_of_h)
                    {
                        if(d.Id == IdHousehold)
                        {
                            IdHousehold = GenarateId();
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

            HouseholdIdChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                bool ok = false;
                List<Model.Population> list_pop_with_no_h = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
                if(list_pop_with_no_h.Count() != 0)
                {
                    foreach(Model.Population x in list_pop_with_no_h)
                    {
                        if(x.Id == Id)
                        {
                            p.Text = x.Name;
                            ok = true;
                            p.IsReadOnly = true;
                            break;
                        }
                    }
                }

                if(ok == false)
                {
                    p.IsReadOnly = false;
                    p.Text = null;
                }
            });

            ReloadCommand = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                IdMembers = Id_Family;

            });

            HouseholdAddressChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                current_Address_Household = Address;
            });

            btnFamily = new RelayCommand<Window>((p) => 
            { 
                if(Address == null)
                {
                    return false;
                }

                return true; 
            }
            , (p) =>
            {
                current_IdOwner = Id;
                current_IdHousehold = IdHousehold;
                current_Address_Household = Address;
                View.FamilyMem wd = new FamilyMem();
                wd.ShowDialog();
            });

            btnClear = new RelayCommand<Page>((p) => { return true; }, (p) => 
            {                             
                Name = null;
                Id = null;
                Address = null;
                IdHousehold = null;
            });

            btnAdd = new RelayCommand<object>((p) =>
            {
                if(Id == null || Name == null || Address == null || Id.Length > 12)
                {
                    return false;
                }

                if (!Check_Id(Id))
                {
                    return false;
                }               

                return true;
            },
            (p) =>
            {
                bool check_is_ok = true;
                bool check_have_population = false;
                List<Model.Population> list_of_population = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();

                if(list_of_population.Count() != 0)
                {
                    foreach (Model.Population x in list_of_population)
                    {
                        if (x.Id == Id && x.Id_Household == null)
                        {
                            check_have_population = true;                          
                            Model.Household_Registration household = new Model.Household_Registration();
                            household.Id = IdHousehold;
                            household.IdOfOwner = Id;
                            household.Address = Address;                          
                            household.NameOfOwner = Name;

                            Model.DataProvider.Ins.DB.Household_Registration.Add(household);
                            Model.DataProvider.Ins.DB.SaveChanges();

                            var change = Model.DataProvider.Ins.DB.Populations.Where(y => y.Id == Id).SingleOrDefault();
                            change.Id_Household = IdHousehold;
                            change.OriginalAddress = Address;
                            change.Address = Address;

                            Model.DataProvider.Ins.DB.SaveChanges();
                            
                            break;
                        }

                        if(x.Id == Id && x.Id_Household != null)
                        {
                            check_is_ok = false;
                            break;
                        }
                       
                    }
                }

                if (!check_have_population && check_is_ok)
                {
                    //Tạo và save nhân khẩu 
                    Model.Population population = new Model.Population();

                    population.Name = Name.Trim();
                    DateTime tmp = new DateTime();
                    tmp = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", null);
                    population.DateOfBirth = tmp;
                    population.PlaceOfBirth = " ";
                    population.Sex = true;
                    population.Relegion = " ";
                    population.Address = Address;
                    population.OriginalAddress = Address;
                    population.Career = " ";
                    population.Id = Id;

                    Model.DataProvider.Ins.DB.Populations.Add(population);
                    Model.DataProvider.Ins.DB.SaveChanges();


                    //Tạo và save hộ khẩu của người vừa khai
                    
                    Model.Household_Registration xx = new Model.Household_Registration();
                    xx.Id = IdHousehold;
                    xx.IdOfOwner = Id;
                    xx.Address = Address;
                    xx.NameOfOwner = Name;

                    Model.DataProvider.Ins.DB.Household_Registration.Add(xx);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    //Sửa nhân khẩu vừa làm
                    var change = Model.DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault();
                    change.Id_Household = IdHousehold;
                    Model.DataProvider.Ins.DB.SaveChanges();                                       
                }          

                //Tạo và thêm thành viên vào hộ khẩu
                if (FamilyViewModel.list_of_family_member.Count() != 0 && check_is_ok)
                {
                    foreach (Model.Population member in FamilyViewModel.list_of_family_member)
                    {
                        bool checkHHPop = true;
                        bool checkIdPop = false;
                        List<Model.Population> l = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
                        foreach(Model.Population k in l)
                        {
                            if(k.Id == member.Id && k.Id == null)
                            {
                                checkIdPop = true;
                                break;
                            }
                            else if(k.Id == member.Id && k.Id != null)
                            {
                                checkHHPop = false;
                            }
                        }

                        if (!checkIdPop && checkHHPop)
                        {
                            member.OriginalAddress = Address;
                            member.Address = Address;
                            Model.DataProvider.Ins.DB.Populations.Add(member);
                            Model.DataProvider.Ins.DB.SaveChanges();
                            Model.Family_Household new_member = new Model.Family_Household();
                            new_member.Id_Person = member.Id;
                            new_member.Id_Owner = Id;
                            new_member.Id_Household = IdHousehold;
                            new_member.Name_Person = member.Name;
                            Model.DataProvider.Ins.DB.Family_Household.Add(new_member);
                            Model.DataProvider.Ins.DB.SaveChanges();
                        }
                        else if (!checkHHPop)
                        {
                            MessageBox.Show(member.Name + " with Id: " + member.Id + " is already has a household registration");
                        }
                        else if(checkIdPop && checkHHPop)
                        {
                            var temp = Model.DataProvider.Ins.DB.Populations.Where(x => x.Id == member.Id).SingleOrDefault();
                            temp.Id_Household = IdHousehold;
                            temp.OriginalAddress = Address;
                            temp.Address = Address;
                            Model.DataProvider.Ins.DB.SaveChanges();

                            Model.Family_Household new_member = new Model.Family_Household();
                            new_member.Id_Person = member.Id;
                            new_member.Id_Owner = Id;
                            new_member.Id_Household = IdHousehold;
                            new_member.Name_Person = member.Name;
                            Model.DataProvider.Ins.DB.Family_Household.Add(new_member);
                            Model.DataProvider.Ins.DB.SaveChanges();
                        }
                    }                    
                    
                }

                //Tạo chủ hộ trong gia đình
                if (check_is_ok)
                {
                    Model.Family_Household owner = new Model.Family_Household();
                    owner.Id_Person = Id;
                    owner.Id_Owner = Id;
                    owner.Id_Household = IdHousehold;
                    owner.Name_Person = Name;
                    Model.DataProvider.Ins.DB.Family_Household.Add(owner);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Create Household Registration Successfully", "Notification!", MessageBoxButton.OK, MessageBoxImage.Information);
                    FamilyViewModel.list_of_family_member.Clear();
                    IdHousehold = GenarateId();
                }

                if (!check_is_ok)
                {
                    MessageBox.Show("This person already have in household registration", "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
                    FamilyViewModel.list_of_family_member.Clear();
                }

                
            });
        }       

        private void Clear(Window p)
        {                  

        }
        private void GetAllControls(Control container)
        {
           
        }

        private string GenarateId()
        {           
            string keychar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string keynum = "0123456789";
            Random random = new Random();
            string code = "";

            int num = random.Next(0, 26);
            code += keychar[num];

            for(int i=0; i<4; i++)
            {
                num = random.Next(0, 10);
                code += keynum[num];
            }

            return code;
        }

        private bool Check_Id(string Id)
        {
            if(long.TryParse(Id , out long a))
            {
                return true;
            }

            return false;
        }
     
    }
  
}
