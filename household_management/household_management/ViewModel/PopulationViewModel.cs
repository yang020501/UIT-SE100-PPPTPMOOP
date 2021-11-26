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
        private bool _isFemale;
        public bool isFemale { get => _isFemale; set { _isFemale = value; OnPropertyChanged(); } }
        private bool _isMale;
        public bool isMale { get => _isMale; set { _isMale = value; OnPropertyChanged(); } }
        public PopulationViewModel()
        {            
            AddingCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (isFemale == true)
                {
                    MessageBox.Show("Female");
                }
                else if (isMale == true)
                {
                    MessageBox.Show("Male");
                }
                else
                {
                    MessageBox.Show("Nothing");
                }
                    
            });
        }

      

       
    }
}
