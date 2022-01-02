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
    class ChangePasswordViewModel : BaseViewModel
    {
        private string password;
        private string new_password;
        private string tmp;
        private bool check1 = false;
        private bool check2 = false;
        private bool check3 = false;    
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ConformCommand { get; set; }
        public ChangePasswordViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p.Name == "FloatingPasswordBox")
                {                   
                    check1 = false;
                    password = p.Password;
                    if(password != null && password != "")
                    {
                        check1 = true;
                    }
                }
                else if(p.Name == "NewPasswordBox")
                {
                    new_password = p.Password;
                    check2 = false;                   
                    if (new_password != null && new_password != "")
                    {
                        check2 = true;
                    }
                }
                else if(p.Name == "NewPasswordBoxRepeat")
                {
                    tmp = p.Password;
                    check3 = false;                   
                    if (tmp != null && tmp != "")
                    {
                        check3 = true;
                    }
                }
            });

            ConformCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!check1 || !check2 || !check3)
                {
                    MessageBox.Show("Not fully entered");
                }
                else if (password != LoginViewModel.passwordX)
                {
                    MessageBox.Show("Incorrect password");
                }
                else if(new_password != tmp)
                {
                    MessageBox.Show("Incorrect confirm new password");
                }
                else
                {
                    int c = int.Parse(LoginViewModel.Id);
                    var tk = Model.DataProvider.Ins.DB.Users.Where(x => x.Id == c).SingleOrDefault();
                    tk.Password = Base64Encode(new_password);
                    Model.DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Password have been change");
                }
            });
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
