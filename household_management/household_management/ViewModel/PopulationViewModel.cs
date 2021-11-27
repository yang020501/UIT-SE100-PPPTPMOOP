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
    class PopulationViewModel : BaseViewModel
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
        public ICommand HouseholdIDChangeCommand { get; set; }
        private bool _isFemale;
        public bool isFemale { get => _isFemale; set { _isFemale = value; OnPropertyChanged(); } }
        private bool _isMale;
        public bool isMale { get => _isMale; set { _isMale = value; OnPropertyChanged(); } }
        public PopulationViewModel()
        {
            List<Model.Household_Registration> list_of_household = Model.DataProvider.Ins.DB.Household_Registration.ToList<Model.Household_Registration>();
            Gender = true;

            HouseholdIDChangeCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { });

            AddingCommand = new RelayCommand<object>((p) => 
            { 
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
                population.PlaceOfBirth = PlaceOfBirth;
                population.Sex = Gender;
                population.Relegion = Religion;
                population.Address = Address;
                population.Id = Id;
                population.Id_Household = HouseholdId;

                Model.DataProvider.Ins.DB.Populations.Add(population);
                Model.DataProvider.Ins.DB.SaveChanges();
                    
            });
        }

        

       
    }
}
