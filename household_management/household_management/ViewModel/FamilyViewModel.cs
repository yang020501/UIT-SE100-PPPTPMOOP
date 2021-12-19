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
    class FamilyViewModel : BaseViewModel
    {
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
        private string __HouseholdId;
        public string HouseholdId { get => __HouseholdId; set { __HouseholdId = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string _HouseholdAddress;
        public string HouseholdAddress { get => _HouseholdAddress; set { _HouseholdAddress = value; OnPropertyChanged(); } }
        private string _Religion;
        public string Religion { get => _Religion; set { _Religion = value; OnPropertyChanged(); } }
        private string _Carrer;
        public string Carrer { get => _Carrer; set { _Carrer = value; OnPropertyChanged(); } }
        public ICommand AddingCommand { get; set; }
        public ICommand DoneCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        private bool _isFemale;
        public bool isFemale { get => _isFemale; set { _isFemale = value; OnPropertyChanged(); } }
        private bool _isMale;
        public bool isMale { get => _isMale; set { _isMale = value; OnPropertyChanged(); } }

        public static List<Model.Population> list_of_family_member = new List<Model.Population>();
        public FamilyViewModel()
        {
            List<Model.Household_Registration> list_of_household = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();
            HouseholdId = HouseholdViewModel.current_IdHousehold;
            HouseholdAddress = HouseholdViewModel.current_Address_Household;

            ClearCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                FamilyName = null;
                Name = null;
                Gender = true;
                PlaceOfBirth = null;               
                Address = null;
                Carrer = null;
                Religion = null;
                Id = null;
                View.FamilyMem wd = new View.FamilyMem();
                wd.Show();
                p.Close();
            });

            AddingCommand = new RelayCommand<object>((p) => 
            {
                if (FamilyName == null || Name == null)
                {
                    return false;
                }

                if (Id == null || Id.Length > 12)
                {
                    return false;
                }

                if (list_of_family_member.Count() != 0)
                {
                    foreach(Model.Population x in list_of_family_member)
                    {
                        if(Id == x.Id)
                        {
                            return false;
                        }
                    }
                }

                if(Id == HouseholdViewModel.current_IdOwner)
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
                Model.Population population = new Model.Population();
                if (isFemale == true)
                {
                    Gender = false;
                }

                if (isMale == true)
                {
                    Gender = true;
                }
                population.Name = FamilyName.Trim() + " " + Name.Trim();
                population.DateOfBirth = DateOfBirth;

                if (PlaceOfBirth == null)
                {
                    PlaceOfBirth = " ";
                }
                population.PlaceOfBirth = PlaceOfBirth;

                if (isFemale == false && isMale == false)
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
                population.Address = Address;
                population.Id = Id;
                population.Id_Household = HouseholdId;

                list_of_family_member.Add(population);

                MessageBox.Show("Successful","Notification!",MessageBoxButton.OK,MessageBoxImage.Information);
            });

            DoneCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                FamilyName = null;
                Name = null;
                Gender = true;
                PlaceOfBirth = null;
                Address = null;
                Carrer = null;
                Religion = null;
                Id = null;
                
                if(list_of_family_member.Count() != 0)
                {
                    foreach (Model.Population x in list_of_family_member)
                    {
                        HouseholdViewModel.Id_Family += "- " + x.Id + "\n";
                    }
                   
                }

                
                p.Close();
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

    }
}
