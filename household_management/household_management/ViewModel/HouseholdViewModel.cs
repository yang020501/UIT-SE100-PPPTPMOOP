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
                if(Id == null || Name == null || Address == null)
                {
                    return false;
                }

                return true;
            },
            (p) =>
            {
                IdHousehold = GenarateId();
                Model.Household_Registration x = new Model.Household_Registration();
                x.Id = IdHousehold;
                x.IdOfOwner = Id;
                x.Address = Address;
                x.NameOfOwner = Name;

                Model.DataProvider.Ins.DB.Household_Registration.Add(x);
                Model.DataProvider.Ins.DB.SaveChanges();
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
