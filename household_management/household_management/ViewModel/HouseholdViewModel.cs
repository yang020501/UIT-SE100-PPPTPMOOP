using household_management.View;
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
    class HouseholdViewModel : BaseViewModel
    {
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private string IdHousehold;
        public ICommand btnClear { get; set; }
        public ICommand btnAdd { get; set; }
        public HouseholdViewModel()
        {
            btnClear = new RelayCommand<Window>((p) => { return true; }, (p) => { Clear(p); });

            btnAdd = new RelayCommand<object>((p) =>
            {
                if(Id == null || Name == null || Address == null || Id.Length > 12)
                {
                    return false;
                }

                return true;
            },
            (p) =>
            {
                bool check_have_population = false;
                List<Model.Population> list_of_population = Model.DataProvider.Ins.DB.Populations.ToList<Model.Population>();

                if(list_of_population.Count() != 0)
                {
                    foreach (Model.Population x in list_of_population)
                    {
                        if (x.Id == Id)
                        {
                            check_have_population = true;
                            IdHousehold = GenarateId();
                            Model.Household_Registration household = new Model.Household_Registration();
                            household.Id = IdHousehold;
                            household.IdOfOwner = Id;
                            household.Address = Address;
                            household.NameOfOwner = Name;

                            Model.DataProvider.Ins.DB.Household_Registration.Add(household);

                            var change = Model.DataProvider.Ins.DB.Populations.Where(y => y.Id == Id).SingleOrDefault();
                            change.Id_Household = IdHousehold;

                            Model.DataProvider.Ins.DB.SaveChanges();
                            break;
                        }
                    }
                }
                if (!check_have_population)
                {
                    //Tạo và save nhân khẩu 
                    Model.Population population = new Model.Population();

                    population.Name = Name.Trim();
                    DateTime tmp = new DateTime();
                    tmp = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", null);
                    population.DateOfBirth = tmp;
                    population.PlaceOfBirth = " ";
                    population.Sex = true;
                    population.Relegion = " ";
                    population.Address = Address;
                    population.Career = " ";
                    population.Id = Id;

                    Model.DataProvider.Ins.DB.Populations.Add(population);


                    //Tạo và save hộ khẩu của người vừa khai
                    IdHousehold = GenarateId();
                    Model.Household_Registration xx = new Model.Household_Registration();
                    xx.Id = IdHousehold;
                    xx.IdOfOwner = Id;
                    xx.Address = Address;
                    xx.NameOfOwner = Name;

                    Model.DataProvider.Ins.DB.Household_Registration.Add(xx);


                    //Sửa nhân khẩu vừa làm
                    var change = Model.DataProvider.Ins.DB.Populations.Where(x => x.Id == Id).SingleOrDefault();
                    change.Id_Household = IdHousehold;
                    Model.DataProvider.Ins.DB.SaveChanges();
                }
            });
        }
        private void Clear(Window p)
        {
            List<Control> list = new List<Control>();
          

        }
        private void GetAllControls(Control container)
        {
           
        }

        private string GenarateId()
        {           
            string keychar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string keynum = "0123456789";
            Random random = new Random();
            string code = "";

            int num = random.Next(0, 26);
            code += keychar[num];

            for(int i=0; i<4; i++)
            {
                num = random.Next(0, 10);
                code += keynum[num];
            }

            return code;
        }

    }
  
}
