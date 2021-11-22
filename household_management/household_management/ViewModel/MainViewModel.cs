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
        public bool isLoad = false;
        public MainViewModel()
        {
            LoadWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                isLoad = true;
                p.Hide();
                View.Login wd = new View.Login();
                wd.ShowDialog();
                var login = new View.Login();
                if (!login.isExist)
                {
                    p.Show();
                }

                p.Close();
            });
        }
    }
}
