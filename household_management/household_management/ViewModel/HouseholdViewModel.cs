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
       
        public ICommand btnClear { get; set; }
        public HouseholdViewModel()
        {
            btnClear = new RelayCommand<Window>((p) => { return true; }, (p) => { Clear(p); });
           
        }
        private void Clear(Window p)
        {
            
          

        }
        private void GetAllControls(Control container)
        {
           
        }

    }
  
}
