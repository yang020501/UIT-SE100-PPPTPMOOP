using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace household_management.ViewModel
{
    class PopulationViewModel : BaseViewModel
    {
        public DateTime DateTimeNow;
        private bool check_IdHousehold = false;
        private string _FamilyName;
        public string FamilyName { get => _FamilyName; set { _FamilyName = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }
        private string _PlaceOfBirth;
        public string PlaceOfBirth { get => _PlaceOfBirth; set { _PlaceOfBirth = value; OnPropertyChanged(); } }
        private bool _Gender;
        public bool Gender { get => _Gender; set { _Gender = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Date;
        public string Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }
        private string __HouseholdId;
        public string HouseholdId { get => __HouseholdId; set { __HouseholdId = value; OnPropertyChanged(); } }
        private string _OriginalAddress;
        public string OriginalAddress { get => _OriginalAddress; set { _OriginalAddress = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _HouseholdAddress;
        public string HouseholdAddress { get => _HouseholdAddress; set { _HouseholdAddress = value; OnPropertyChanged(); } }
        private string _Religion;
        public string Religion { get => _Religion; set { _Religion = value; OnPropertyChanged(); } }
        private string _Carrer;
        public string Carrer { get => _Carrer; set { _Carrer = value; OnPropertyChanged(); } }
        private string _Photo;
        public string Photo { get => _Photo; set { _Photo = value; OnPropertyChanged(); } }
        public ICommand AddingCommand { get; set; }
        //public ICommand ResetCommand { get; set; }
        public ICommand HouseholdIDChangeCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand Choosebtn { get; set; }
        private bool _isFemale;
        public bool isFemale { get => _isFemale; set { _isFemale = value; OnPropertyChanged(); } }
        private bool _isMale;
        public bool isMale { get => _isMale; set { _isMale = value; OnPropertyChanged(); } }
        
        public PopulationViewModel()

        {
            DateOfBirth = DateTime.Today;
            Photo = "/household_management;component/Resources/account.jpg";
            Date = DateTime.Now.ToString("MM/dd/yyyy");
            DateOfBirth = DateTime.Now;

            List<Model.Household_Registration> list_of_household = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();         

            ClearCommand = new RelayCommand<Page>((p) => { return true; }, (p) => {
                FamilyName = null;
                Name = null;
                Gender = true;
                PlaceOfBirth = null;
                HouseholdId = null;
                Address = null;
                Carrer = null;
                Religion = null;
                Id = null;
                
            });

            //ResetCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
            //    View.Populations wd = new View.Populations();
            //    wd.Show()ar
            //    p.Close();
            //});

            HouseholdIDChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => {              
                if (list_of_household.Count() != 0)
                {
                    foreach (Model.Household_Registration x in list_of_household)
                    {
                        if (x.Id.Trim() == p.Text.Trim())
                        {
                            HouseholdAddress = x.Address;
                            check_IdHousehold = true;
                            MessageBox.Show("Household have been registed, you are now able to regist a population","Notification1",MessageBoxButton.OK,MessageBoxImage.Information);
                            break;
                        }
                    }
                }
                

            });
            // Choos picture btn
            Choosebtn = new RelayCommand<System.Windows.Controls.Image>((p) => { return true; },(p) =>
            {
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();

                open.Filter = "(*.jpg)|*.jpg|(*.*)|*.*";

                if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Photo = open.FileName; // để lưu hình thẻ 
                    Uri fileUri = new Uri(open.FileName);
                    p.Source = new BitmapImage(fileUri);
                }
            });

            AddingCommand = new RelayCommand<object>((p) => 
            { 
                if(FamilyName == null || Name == null)
                {
                    return false;
                }
                
                if(Id == null || Id.Length > 12)
                {
                    return false;
                }

                List<Model.Population> list_of_population = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
                if(list_of_population.Count() != 0)
                {
                    foreach(Model.Population x in list_of_population)
                    {
                        if(x.Id == Id)
                        {
                            return false;
                        }
                    }
                }

                if(HouseholdId != null && check_IdHousehold == false)
                {
                    return false;
                }

                if (!Check_Id(Id))
                {
                    return false;
                }

                return true; 
            }, (p) => 
            {              
                Model.Population population = new Model.Population();
                if(isFemale == true)
                {
                    Gender = false;
                }
                
                if(isMale == true)
                {
                    Gender = true;
                }
                population.Name = FamilyName.Trim() + " " + Name.Trim();
                population.DateOfBirth = DateOfBirth;

                if(PlaceOfBirth == null)
                {
                    PlaceOfBirth = " ";
                }              
                population.PlaceOfBirth = PlaceOfBirth;

                if(isFemale == false && isMale == false)
                {
                    Gender = true;
                }
                population.Sex = Gender;

                if (Religion == null)
                {
                    Religion = "None";
                }
                population.Relegion = Religion;

                if (Carrer == null)
                {
                    Carrer = " ";
                }
                population.Career = Carrer;

                if (Address == null)
                {
                    Address = " ";
                }

                if(Photo != "" && Photo != null && Photo != "/household_management;component/Resources/account.jpg" )

                {
                    string namePhoto = System.IO.Path.GetFileName(Photo);
                    namePhoto = Id.ToString()+".jpg";
                    population.Photo = namePhoto;
                    //check if not have photo
                    if (!System.IO.File.Exists("../../hinhthe/" + namePhoto))
                        //copy image into file hinhthe
                        System.IO.File.Copy(Photo, "../../hinhthe/" + namePhoto);
                    
                }

                population.Address = Address;                
                population.Id = Id;
                
                population.Id_Household = HouseholdId;
                population.isAbsence = false;
                population.isTResidence = false;
                if(HouseholdId != null)
                {
                    var home = Model.DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == HouseholdId).SingleOrDefault();
                    population.OriginalAddress = home.Address;
                }

                if (!Check_is_Id_exist(population.Id))
                {         
                    Model.DataProvider.Ins.DB.Populations.Add(population);
                    Model.DataProvider.Ins.DB.SaveChanges();

                    if (population.Id_Household != null)
                    {
                        Model.Family_Household newmember = new Model.Family_Household();
                        newmember.Id_Household = population.Id_Household;
                        var h = Model.DataProvider.Ins.DB.Household_Registration.Where(x => x.Id == population.Id_Household).SingleOrDefault();
                        newmember.Id_Owner = h.IdOfOwner;
                        newmember.Id_Person = population.Id;
                        newmember.Name_Person = population.Name;
                        Model.DataProvider.Ins.DB.Family_Household.Add(newmember);
                        Model.DataProvider.Ins.DB.SaveChanges();
                    }

                MessageBox.Show("Add Successfully!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Id is exist please try again!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                isMale = false;
                isFemale = false;
                
            });
        }

        private bool Check_Id(string Id)
        {
            if (long.TryParse(Id, out long a))
            {
                return true;
            }

            return false;
        }

        private bool Check_is_Id_exist(string Id)
        {
            List<Model.Population> populations = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();
            if(populations.Count() != 0)
            {
                foreach (Model.Population person in populations)
                {
                    if(person.Id == Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
