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
    class AddAccountViewModel : BaseViewModel
    {
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _PasswordRepeat;
        public string PasswordRepeat { get => _PasswordRepeat; set { _PasswordRepeat = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ConformCommand { get; set; }
        private bool check1 = false;
        private bool check2 = false;
        public AddAccountViewModel()
        {
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {

                if (p.Name == "PasswordBox")
                {
                    Password = p.Password;
                    check1 = false;
                    if (Password != null && Password != "")
                    {
                        check1 = true;
                    }
                }
                else if (p.Name == "PasswordBoxRepeat")
                {
                    PasswordRepeat = p.Password;
                    check2 = false;
                    if (PasswordRepeat != null && PasswordRepeat != "")
                    {
                        check2 = true;
                    }
                }
            });

            ConformCommand = new RelayCommand<Window>((p) => { return (check1 && check2); }, (p) =>
            {
                if(Name == null || Name == "" || UserName == null || UserName == "")
                {
                    MessageBox.Show("Not fully entered");
                }
                else if(UserName.Length > 15)
                {
                    MessageBox.Show("User name is too long");
                }
                else if (!CheckUserName(UserName))
                {
                    MessageBox.Show("User name is exist, pick another one");
                }
                else if(Password != PasswordRepeat)
                {
                    MessageBox.Show("The repeat password is incorrect, try again");
                    Console.WriteLine("aaaaaaaaaaaaaaaaaa");
                }
                else
                {
                    if (MessageBox.Show("Do you want to ADD this account?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Model.User new_user = new Model.User();
                            new_user.Name = Name;
                            new_user.Username = UserName;
                            new_user.Password = Base64Encode(Password);
                            new_user.Tier = 2;
                            new_user.Sex = true;
                            new_user.IdentityNum = "###########";
                            new_user.DateOfBirth = DateTime.Now;
                            Model.DataProvider.Ins.DB.Users.Add(new_user);
                            Model.DataProvider.Ins.DB.SaveChanges();

                            Name = null;
                            Password = null;
                            PasswordRepeat = null;
                            UserName = null;

                            MessageBox.Show("Successfully adding a user");
                            p.Close();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            });
        }

        private bool CheckUserName(string Username)
        {
            List<Model.User> list_user = Model.DataProvider.Ins.DB.Users.ToList<Model.User>();
            if(list_user.Count() != 0)
            {
                foreach(Model.User x in list_user)
                {
                    if(x.Username == Username)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
