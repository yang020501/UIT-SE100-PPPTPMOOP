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
    class MainViewModel : BaseViewModel
    {
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Role;
        public string Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }
        public ICommand LoadWindowCommand{ get; set; }
        public ICommand LoadPopuationWindowCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand LoadManageButtonCommand { get; set; }
        public bool isLoad = false;
        public MainViewModel()
        {
            LoadManageButtonCommand = new RelayCommand<Button>((p) => { return true; }, (p) => 
            { 
                if(Role == "Manager")
                {
                    p.Visibility = Visibility.Visible;
                }
                else
                {
                    p.Visibility = Visibility.Hidden;
                }
            });

            LoadWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                isLoad = true;
                if (!LoginViewModel.isReLogin)
                {
                    p.Hide();
                    View.Login wd = new View.Login();
                    wd.ShowDialog();

                    if (wd.DataContext == null)
                        return;

                    if (LoginViewModel.isLogin)
                    {
                        p.Show();
                    }
                    else
                    {
                        p.Close();
                    }
                }

                Name = LoginViewModel.Name;
                Id = LoginViewModel.Id;
                Role = LoginViewModel.Role;

                

            });

            LoadPopuationWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                View.Populations wd = new View.Populations();
                wd.DataContext = new PopulationViewModel();
                wd.ShowDialog();              
            });

            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {               
                View.Login wd = new View.Login();
                wd.Show();                             
                LoginViewModel.isLogin = false;
                LoginViewModel.isReLogin = true;
                p.Close();
            });
        }
    }
}
