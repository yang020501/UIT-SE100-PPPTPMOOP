using household_management.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace household_management.ViewModel
{
    class AddPageViewModel : BaseViewModel
    {
        private Frame _pFrame = new Frame();
        public Frame pFrame { get => _pFrame; set { _pFrame = value; OnPropertyChanged(); } }

        private Frame _hFrame = new Frame();
        public Frame hFrame { get => _hFrame; set { _hFrame = value; OnPropertyChanged(); } }

        private Frame _tFrame = new Frame();
        public Frame tFrame { get => _tFrame; set { _tFrame = value; OnPropertyChanged(); } }

        private Frame _aFrame = new Frame();
        public Frame aFrame { get => _aFrame; set { _aFrame = value; OnPropertyChanged(); } }

        private Frame _rFrame = new Frame();
        public Frame rFrame { get => _rFrame; set { _rFrame = value; OnPropertyChanged(); } }

        private int _Selected;
        public int Selected
        {
            get => _Selected;
            set
            {
                _Selected = value; OnPropertyChanged();
                switch (_Selected)
                {
                    case 0: openPopulationsPage(); break;
                    case 1: openHouseholdPage(); break;
                    case 2: openTransferPage(); break;
                    case 3: openAbsencePage(); break;
                    case 4: openResidencePage(); break;

                }
            }
        }

        private void openResidencePage()
        {
           
        }

        private void openAbsencePage()
        {
           
        }

        private void openTransferPage()
        {
            
        }

        private void openHouseholdPage()
        {
            hFrame.Refresh();
            HouseholdPage page = new HouseholdPage();
            HouseholdViewModel vm = new HouseholdViewModel();
            page.DataContext = null;
            page.DataContext = vm;
            hFrame.Content = page;
        }

        private void openPopulationsPage()
        {
            pFrame.Refresh();
            PopulationsPage page = new PopulationsPage();            
            PopulationViewModel vm = new PopulationViewModel();
            page.DataContext = null;
            page.DataContext = vm;
            pFrame.Content = page;
        }

        public AddPageViewModel()
        {

        }
    }

    

}
