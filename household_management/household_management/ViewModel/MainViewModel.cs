using household_management.Model;
using household_management.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        private ImageSource _SPhoto;
        public ImageSource SPhoto { get => _SPhoto; set { _SPhoto = value; OnPropertyChanged(); } }

        private string _Photo;
        public string Photo { get => _Photo; set { _Photo = value; OnPropertyChanged(); } }

        public ICommand LoadWindowCommand{ get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand LoadAccount { get; set; }
        public bool isLoad = false;

        private ObservableCollection<Population> PopulationsList;
        private ObservableCollection<Household_Registration> HouseholdList;
        private ObservableCollection<Transfer_Household> TransferList;
        private ObservableCollection<Temporary_Absence> AbsenceList;
        private ObservableCollection<Temporary_Residence> ResidenceList;

        private Frame main = new Frame();
        public Frame Main { get => main; set { main = value; OnPropertyChanged(); } }

        private bool _reportSelected;
        public bool ReportSelected { get => _reportSelected;set { _reportSelected = value; OnPropertyChanged(); openReportForm(); } }

        private bool _populationsForm;
        public bool PopulationsForm { get => _populationsForm; set { _populationsForm = value; OnPropertyChanged(); openPopulationsForm(); } }

        private bool _householdForm;
        public bool HouseholdForm { get => _householdForm; set { _householdForm = value; OnPropertyChanged(); openHouseholdForm(); } }

        private bool _transferForm;
        public bool TransferForm { get => _transferForm; set { _transferForm = value; OnPropertyChanged(); openTransferForm(); } }

        private bool _absenceForm;
        public bool AbsenceForm { get => _absenceForm; set { _absenceForm = value; OnPropertyChanged(); openAbsenceForm(); } }

        private bool _residenceForm;
        public bool ResidenceForm { get => _residenceForm; set { _residenceForm = value; OnPropertyChanged(); openResidenceForm(); } }  

        private bool _addSelected;
        public bool AddSelected { get => _addSelected;set {  _addSelected = value;OnPropertyChanged();  openAddPage(); ; } }

        private bool _statisticsSelected;
        public bool StatisticsSelected { get => _statisticsSelected; set { _statisticsSelected = value; OnPropertyChanged(); openStatisticPage(); ; } }
      

        private bool _searchSelected;
        public bool SearchSelected { get => _searchSelected; set { _searchSelected = value; OnPropertyChanged(); openSearchPage(); } }

        private bool _manageSelected;
        public bool ManageSelected { get => _manageSelected; set { _manageSelected = value; OnPropertyChanged(); openManage(); } }

        private bool _changePasswordSelected;
        public bool ChangePasswordSelected { get => _changePasswordSelected; set { _changePasswordSelected = value; OnPropertyChanged(); openPasswordChange(); } }
        private bool _infoSelected;
        public bool InfoSelected { get => _infoSelected; set { _infoSelected = value; OnPropertyChanged(); openInformChange(); } }
        public static MainViewModel data { get; set; }

        AddPage aView = new AddPage();

        private void openInformChange()
        {
            if(InfoSelected == true)
            {
                Info wd = new Info();
                wd.ShowDialog();
                InfoSelected = false;
            }
        }

        private void openPasswordChange()
        {
            if(ChangePasswordSelected == true)
            {
                ChangePassword wd = new ChangePassword();
                wd.ShowDialog();
                ChangePasswordSelected = false;
            }
        }

        private void openManage()
        {
            if(ManageSelected == true && LoginViewModel.Role == "Manager")
            {
                main.Refresh();
                main.Content = null;
                AccountPage page = new AccountPage();
                AccountManagerViewModel.Vm = data;              
                main.Content = page;
                ManageSelected = false;
            }
            else if(ManageSelected == true && LoginViewModel.Role != "Manager")
            {
                MessageBox.Show("you do not have the authority to accsess");
                ManageSelected = false;
            }
        }
        private void openStatisticPage()
        {
            if(StatisticsSelected == true)
            {
                main.Refresh();
                main.Content = null;
                ChartPageViewModel vm = new ChartPageViewModel();
                ChartPageView page = new ChartPageView();
                page.DataContext = null;
                page.DataContext = vm;
                main.Content = page;
                StatisticsSelected = false;

            }    
        }

        private void openAddPage()
        {            
            if(AddSelected == true)
            {
                main.Refresh();
                main.Content = null;
                AddPageViewModel vm = new AddPageViewModel();
                AddPage addPage = new AddPage();
                addPage.DataContext = null;
                addPage.DataContext = vm;
                main.Content = addPage;
                AddSelected = false;
            }
          
        }
        private void openSearchPage()
        {
            if (SearchSelected == true)
            {
                main.Refresh();
                SearchViewModel vm = new SearchViewModel();
                Search wd = new Search();
                wd.DataContext = vm;
                wd.ShowDialog();
                SearchSelected = false;
            }
        }
        private void openReportForm()
        {
            if(ReportSelected == true)
            {
                main.Refresh();
              
                // 
                Report.Report report = new Report.Report();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info;
                //// dinh dang lai info
                //info = report.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //report.Database.Tables[0].ApplyLogOnInfo(info);
                // xu ly len form 
                Reports wd = new Reports();
                // gan nguon du lieu
                setDataReport();

                report.SetParameterValue("userName", Name);
                report.SetParameterValue("userId", Id);
                if (Role == "Manager")
                {
                    report.SetParameterValue("userRole", "Quản lý");
                }
                else
                    report.SetParameterValue("userRole", "Nhân viên");
                report.SetParameterValue("slNK", PopulationsList.Count);                
                report.SetParameterValue("slHK", HouseholdList.Count);
                report.SetParameterValue("slCK", TransferList.Count);
                report.SetParameterValue("slTV", AbsenceList.Count);
                report.SetParameterValue("slTT", ResidenceList.Count);
                report.SetParameterValue("slNHK", getCount(PopulationsList, 0));
                report.SetParameterValue("slNCHK", HouseholdList.Count);

                wd.reportViewer.ReportSource = report;
                
                // show
                wd.ShowDialog();
                ReportSelected = false;

            }
        }
        private int getCount(ObservableCollection<Population> PopulationsList, int type)
        {

            int count = 0;
            foreach (Population item in PopulationsList)
            {
                if (item.Id_Household != null)
                {
                    count++;
                }
            }
            if (type == 0)
                return count;
            else
                return PopulationsList.Count - count;
        }
        private void openPopulationsForm()
        {
            if (PopulationsForm == true)
            {
                Report.formAddPopulations form = new Report.formAddPopulations();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info;
                //// dinh dang lai info
                //info = form.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //form.Database.Tables[0].ApplyLogOnInfo(info);
                //// xu ly len form 
                PopulationsForm wd = new PopulationsForm();
                // gan nguon du lieu
                wd.pViewer.ReportSource = form;

                //show
                wd.Show();
                PopulationsForm = false;
            }
        }
        private void openHouseholdForm()
        {
            if (HouseholdForm == true)
            {
                Report.formAddHousehold form = new Report.formAddHousehold();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info;
                //// dinh dang lai info
                //info = form.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //form.Database.Tables[0].ApplyLogOnInfo(info);
                //// xu ly len form 
                HouseholdForm wd = new HouseholdForm();
                // gan nguon du lieu
                wd.hViewer.ReportSource = form;

                //show
                wd.Show();

                HouseholdForm = false;
            }
        }
        private void openTransferForm()
        {
            if (TransferForm == true)
            {
                Report.formAddTransfer form = new Report.formAddTransfer();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info;
                //// dinh dang lai info
                //info = form.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //form.Database.Tables[0].ApplyLogOnInfo(info);
                // xu ly len form 
                TransferForm wd = new TransferForm();
                // gan nguon du lieu
                wd.tViewer.ReportSource = form;

                //show
                wd.Show();
                TransferForm = false;
            }
        }
        private void openAbsenceForm()
        {
            if (AbsenceForm == true)
            {
                Report.formAddAbsence form = new Report.formAddAbsence();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info = new CrystalDecisions.Shared.TableLogOnInfo();
                //// dinh dang lai info
                //info = form.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //form.Database.Tables[0].ApplyLogOnInfo(info);
                // xu ly len form 
                AbsenceForm wd = new AbsenceForm();
                // gan nguon du lieu
                wd.aViewer.ReportSource = form;

                //show
                wd.Show();
                AbsenceForm = false;
            }
        }
        private void openResidenceForm()
        {
            if (ResidenceForm == true)
            {
                Report.formAddResidence form = new Report.formAddResidence();
                //
                //CrystalDecisions.Shared.TableLogOnInfo info = new CrystalDecisions.Shared.TableLogOnInfo();
                //// dinh dang lai info
                //info = form.Database.Tables[0].LogOnInfo;
                //info.ConnectionInfo.ServerName = ".\\(local)";
                //info.ConnectionInfo.DatabaseName = "HoKhau";
                //info.ConnectionInfo.IntegratedSecurity = true;
                //form.Database.Tables[0].ApplyLogOnInfo(info);
                // xu ly len form 
                ResidenceForm wd = new ResidenceForm();
                // gan nguon du lieu
                wd.rViewer.ReportSource = form;

                //show
                wd.Show();
                ResidenceForm = false;
            }
        }


        private void setDataReport()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            HouseholdList = new ObservableCollection<Household_Registration>(DataProvider.Ins.DB.Household_Registration);
            TransferList = new ObservableCollection<Transfer_Household>(DataProvider.Ins.DB.Transfer_Household);
            AbsenceList = new ObservableCollection<Temporary_Absence>(DataProvider.Ins.DB.Temporary_Absence);
            ResidenceList = new ObservableCollection<Temporary_Residence>(DataProvider.Ins.DB.Temporary_Residence);
        }


        public MainViewModel()
        {
            StatisticsSelected = true;


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

                data = (MainViewModel)p.DataContext;
                Name = LoginViewModel.Name;
                Id = LoginViewModel.Id;
                Role = LoginViewModel.Role;
                loadPic(Id);



            });

         

            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {               
                View.Login wd = new View.Login();
                wd.Show();                             
                LoginViewModel.isLogin = false;
                LoginViewModel.isReLogin = true;
                main.Refresh();
                main.Content = null;
                p.Close();
                
            });
           
           
        }
       public void loadPic(string Id="0000")
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
