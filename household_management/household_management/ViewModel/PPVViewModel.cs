using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    class PPVViewModel : BaseViewModel
    {
        DataTable dt ;

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        private string _DateOfBirth;
        public string DateOfBirth { get => _DateOfBirth; set { _DateOfBirth = value; OnPropertyChanged(); } }

        private string _PlaceOfBirth;
        public string PlaceOfBirth { get => _PlaceOfBirth; set { _PlaceOfBirth = value; OnPropertyChanged(); } }

        private string _Relegion;
        public string Relegion { get => _Relegion; set { _Relegion = value; OnPropertyChanged(); } }

        private string _Career;
        public string Career { get => _Career; set { _Career = value; OnPropertyChanged(); } }

        private string _Id_Household;
        public string Id_Household { get => _Id_Household; set { _Id_Household = value;OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address;set { _Address = value; OnPropertyChanged(); } }

        private string _HAddress;
        public string HAddress { get => _HAddress; set { _HAddress = value;OnPropertyChanged(); } }

        private bool _MaleChoice;
        public bool MaleChoice { get => _MaleChoice; set { _MaleChoice = value; OnPropertyChanged(); } }
        private bool _FemaleChoice;
        public bool FemaleChoice { get => _FemaleChoice; set { _FemaleChoice = value; OnPropertyChanged(); } }

        private ImageSource _SPhoto;
        public ImageSource SPhoto { get => _SPhoto; set { _SPhoto = value; OnPropertyChanged(); } }

        private string _Photo;
        public string Photo { get => _Photo; set { _Photo = value; OnPropertyChanged(); } }


        private DataView dvPopulations;
        public DataView DvPopulations { get => dvPopulations; set { dvPopulations = value; OnPropertyChanged(); } }


        private ObservableCollection<Population> PopulationsList;

        public ICommand Updatebtn { get; set; }
        public ICommand Deletebtn { get; set; }
        public ICommand Choosebtn { get; set; }

        public PPVViewModel()
        {
           
            NewTablePopulations();
            //Update
            Updatebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Populations.Where(x => x.Id == Id);

                if (displayList == null)
                    return false;
                return true;

            }, (p) =>
            {
                var tmp = DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault();
                tmp.Name = Name;
                tmp.Address = Address;
                tmp.Career = Career;
                tmp.Relegion = Relegion;
                tmp.Id_Household = Id_Household;
                if (MaleChoice == true)
                    tmp.Sex = true;
                else
                    tmp.Sex = false;
                tmp.PlaceOfBirth = PlaceOfBirth;             

                if ( Photo != "" && Photo != null)
                {
                    
                    string namePhoto = System.IO.Path.GetFileName(Photo);
                    namePhoto = Id.ToString() + ".jpg";
                    //check if not have photo
                    if (!System.IO.File.Exists("../../hinhthe/" + Photo))
                        //copy image into file hinhthe
                        System.IO.File.Copy(Photo, "../../hinhthe/" + namePhoto, true);
                    tmp.Photo = namePhoto;
                }
                try
                {
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Id_Household is invalid or null!\nYour other changes will be SAVED", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                //reload 
                Selected = null;
                Photo = null;
                SPhoto = null;
                NullProperty();
                NewTablePopulations();
                p.ItemsSource = dvPopulations;
                MessageBox.Show("Update Successful!", "Notifications!", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            });
            //Delete
            Deletebtn = new RelayCommand<DataGrid>((p) =>
            {
                if (Selected != null)
                    return true;
                else
                    return false;

            }, (p) =>
            {

                if(MessageBox.Show("Do you want to REMOVE?\nIt will REMOVE relavant Page like Absence,Transfer,Residence","Warning!",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Household_Registration household = DataProvider.Ins.DB.Household_Registration.Where(x => x.IdOfOwner == Id).SingleOrDefault();
                    if (household == null)
                    {
                        try
                        {
                            Temporary_Residence residence = DataProvider.Ins.DB.Temporary_Residence.Where(x => x.Id_Owner == Id).SingleOrDefault();
                            if (residence != null)
                            DataProvider.Ins.DB.Temporary_Residence.Remove(residence);

                            Temporary_Absence absence = DataProvider.Ins.DB.Temporary_Absence.Where(x => x.Id_Owner == Id).SingleOrDefault();
                             if (absence != null)
                            DataProvider.Ins.DB.Temporary_Absence.Remove(absence);

                            Transfer_Household transfer = DataProvider.Ins.DB.Transfer_Household.Where(x => x.Id_Owner == Id).SingleOrDefault();
                            if (transfer != null)
                            DataProvider.Ins.DB.Transfer_Household.Remove(transfer);

                            DataProvider.Ins.DB.Populations.Remove(DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault());

                            DataProvider.Ins.DB.SaveChanges();


                        // reload view table
                        Photo = null;
                        Selected = null;
                        SPhoto = null;
                        NullProperty();
                        NewTablePopulations();
                        p.ItemsSource = dvPopulations;

                        }
                        catch (Exception e)
                        {

                            MessageBox.Show(e.Message, "Notification!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This person is a Owner of Household: " + household.Id + "\nPlease REMOVE in Household first!", "Notification!", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }                
               


            })
            {

            };
            //ChoosePicture btn
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
            });
        }
        

        private DataRowView _Selected;
        public DataRowView Selected
        {
            get => _Selected;
            set
            {
                _Selected = value;
                OnPropertyChanged();
                if (Selected != null)
                {
                    Name = (string)Selected.Row["Name"];
                    Id = (string)Selected.Row["Id"];
                    if ((string)Selected.Row["Gender"] == "Male")
                    {
                        MaleChoice = true;
                        FemaleChoice = false;
                    }
                    else
                    {
                        FemaleChoice = true;
                        MaleChoice = false;
                    }
                    DateOfBirth = (string)Selected.Row["DateOfBirth"];
                    PlaceOfBirth = (string)Selected.Row["PlaceOfBirth"];
                    Id_Household = (string)Selected.Row["Id_Household"];
                    Address = (string)Selected.Row["Address"];
                    Relegion = (string)Selected.Row["Relegion"];
                    Career = (string)Selected.Row["Career"];
                    HAddress = (string)Selected.Row["HAddress"];
                    if ((string)Selected.Row["Photo"] != null && (string)Selected.Row["Photo"] != "")

                    {
                        Photo = (string)Selected.Row["Photo"];
                        SPhoto = BitmapFromUri(new Uri(System.IO.Path.GetFullPath("../../hinhthe/" + Photo)))   ; // get picture
                    }
                    else
                    {
                        Photo = "";
                        SPhoto = null;
                    }
                   

                }
            }
        }
        private void NullProperty()
        {
            Photo = null;
            FemaleChoice = false;
            MaleChoice = false;
            Name = null;
            DateOfBirth = null;
            Id = null;
            Relegion = null;
            Career = null;
            Id_Household = null;
            Address = null;
            HAddress = null;
          
            
        }
        public void Load()
        {
            
            NewTablePopulations();
        }
        private void NewTablePopulations()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            dt = new DataTable();

            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("PlaceOfBirth");             
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("Address");
            dt.Columns.Add("Relegion");
            dt.Columns.Add("Career");
            dt.Columns.Add("Photo");
            dt.Columns.Add("HAddress");
            //fill datatablejk
            for (int i = 0; i < PopulationsList.Count; i++)
            {
                dt.Rows.Add
                    (
                         CheckData(PopulationsList[i],i)
                    );
            }
            dvPopulations = new DataView(dt);
        }
        // Check if any fields is null
        private string[] CheckData(Population item,int stt)
        {
            var link = DataProvider.Ins.DB.Household_Registration.Where(x => x.IdOfOwner == item.Id).SingleOrDefault();
            string[] list = new string[12];
            list[0] = (stt + 1).ToString();
            list[1] = check(item.Id);
            list[2] = check(item.Name);
            list[3] = check(item.Sex);
            list[4] = check(item.DateOfBirth);
            list[5] = check(item.PlaceOfBirth);
            if (link != null)
                list[6] = check(link.Id);
            else list[6] = "";
            list[7] = check(item.Address);
            list[8] = check(item.Relegion);
            list[9] = check(item.Career);
            list[10] = check(item.Photo);          
            if (link != null)
                list[11] = check(link.Address);
            else list[11] = "";
            return list;
        }
        // Convert null, string or any type to Valid view data
        private string check(object  txt)
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
        
        public void doSearch(DataGrid dtg ,string find,string form)
        {
            form += " Like '%{0}%'";
            if (dvPopulations.Count < 0) // if nothing return to prevent error
                return;
            DvPopulations.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvPopulations;

        }
        private  ImageSource BitmapFromUri(Uri source)
        {
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
