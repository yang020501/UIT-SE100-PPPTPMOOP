using household_management.Model;
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
    class LoginViewModel : BaseViewModel
    {
        public static string passwordX;
        public static bool isReLogin = false;
        public static bool isLogin = false;
        public static string Name;
        public static string Id;
        public static string Role;
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand ExistCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            isLogin = false;
            Password = "";
            UserName = "";
            ExistCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
            {
                return;
            }
            string passEncode = Base64Encode(Password);
            var accCount = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode).Count();

            if (accCount > 0 && !isReLogin)
            {
                var accCountInfo = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode).SingleOrDefault();
                Name = accCountInfo.Name;
                Id = accCountInfo.Id.ToString();
                int type = (int)accCountInfo.Tier;
                var userRole = DataProvider.Ins.DB.UserRoles.Where(x => x.Id == type).SingleOrDefault();
                Role = userRole.NameRole;
                isLogin = true;
                passwordX = Password;
                p.Close();
            }
            else if (accCount > 0 && isReLogin)
            {
                var accCountInfo = DataProvider.Ins.DB.Users.Where(x => x.Username == UserName && x.Password == passEncode).SingleOrDefault();
                Name = accCountInfo.Name;
                Id = accCountInfo.Id.ToString();
                int type = (int)accCountInfo.Tier;
                var userRole = DataProvider.Ins.DB.UserRoles.Where(x => x.Id == type).SingleOrDefault();
                Role = userRole.NameRole;
                MainWindow wd = new MainWindow();              
                wd.Show();
                p.Close();
            }
            else
            {
                isLogin = false;
                MessageBox.Show("Wrong password or user name","Warning!",MessageBoxButton.OK,MessageBoxImage.Error);

            }
        }        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
