using household_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace household_management.ViewModel
{
    class InfomationViewModel : BaseViewModel
    {
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Identity;
        public string Identity { get => _Identity; set { _Identity = value; OnPropertyChanged(); } }
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }
        private bool _FemaleChoice;
        private bool _MaleChoice;
        public bool FemaleChoice { get => _FemaleChoice; set { _FemaleChoice = value; OnPropertyChanged(); } }
        public bool MaleChoice { get => _MaleChoice; set { _MaleChoice = value; OnPropertyChanged(); } }
        private ImageSource _SPhoto;
        public ImageSource SPhoto { get => _SPhoto; set { _SPhoto = value; OnPropertyChanged(); } }


        private string _Photo;
        public string Photo { get => _Photo; set { _Photo = value; OnPropertyChanged(); } }

        public ICommand Choosebtn { get; set; }
        public static MainViewModel Vm { get; set; }

        public InfomationViewModel()
        {
           
            try
            {
                Name = LoginViewModel.Name;
                Identity = LoginViewModel.Identity;
                DateOfBirth = LoginViewModel.Dateofbirth;
                if (LoginViewModel.Sex == true)
                {
                    MaleChoice = true;
                }
                else if (LoginViewModel.Sex == false)
                {
                    FemaleChoice = true;
                }
            }
            catch (Exception e)
            {

            }

            Choosebtn = new RelayCommand<System.Windows.Controls.Image>((p) => { return true; }, (p) =>
            {
                System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();

                open.Filter = "(*.jpg)|*.jpg|(*.*)|*.*";

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Photo = open.FileName; // để lưu hình thẻ 
                    SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath(Photo)));
                    open.Dispose();
                    //Uri fileUri = new Uri(open.FileName);
                    //p.Source = new BitmapImage(fileUri);
                }
                int tmp_id = int.Parse(LoginViewModel.Id);
                var tmp = Model.DataProvider.Ins.DB.Users.Where(x => x.Id == tmp_id).SingleOrDefault();
                if (Photo != "" && Photo != null)
                {
                    string namePhoto = System.IO.Path.GetFileName(Photo);
                    namePhoto = LoginViewModel.Id + ".jpg";
                    //check if not have photo
                    if (!System.IO.File.Exists("../../userhinhthe/" + Photo))
                        //copy image into file hinhthe
                        System.IO.File.Copy(Photo, "../../userhinhthe/" + namePhoto, true);
                    tmp.PhotoUser = namePhoto;
                }

                Model.DataProvider.Ins.DB.SaveChanges();
                var linktemp = DataProvider.Ins.DB.Users.Where(x => x.IdentityNum == Identity).SingleOrDefault();
                Vm.loadPic(check(linktemp.Id));

            });
            var link = DataProvider.Ins.DB.Users.Where(x => x.IdentityNum == Identity).SingleOrDefault();
            loadPic(check(link.Id));


        }
        public void loadPic(string Id = "0000")
        {
            if (Id == null)
                return;
            int tmp = int.Parse(Id);
            var link = DataProvider.Ins.DB.Users.Where(x => x.Id == tmp).SingleOrDefault();
            if (link != null)
            {

                Photo = check(link.PhotoUser);
                try
                {
                    SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath("../../userhinhthe/" + Photo))); // get picture
                }
                catch (Exception e)
                {
                    SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath("../../userhinhthe/" + Photo)));
                }


            }

        }
        private string check(object txt)
        {
            DateTime dateTime = new DateTime();
            bool gender = new bool();
            if (txt == null)
                return "";
            else if (txt.GetType() == dateTime.GetType())
            {
                dateTime = (DateTime)txt;
                return dateTime.ToString("dd/MM/yyyy");
            }
            else if (txt.GetType() == gender.GetType())
            {
                gender = (bool)txt;
                if (gender == true)
                    return "Male";
                else return "Female";
            }
            return txt.ToString();
        }


        private ImageSource BitmapFromUri(Uri source)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmap.UriSource = source;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                return bitmap;
            }
            catch
            {
                source = new Uri(System.IO.Path.GetFullPath("../../Resources/account.jpg"));
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmap.UriSource = source;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                return bitmap;
            }

        }
    }
}
