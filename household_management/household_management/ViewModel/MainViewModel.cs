using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace household_management.ViewModel
{
    class MainViewModel : BaseViewModel
    {       
        public ICommand LoadWindowCommand{ get; set; }
        public ICommand LoadPopuationWindowCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public bool isLoad = false;
        public MainViewModel()
        {
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
