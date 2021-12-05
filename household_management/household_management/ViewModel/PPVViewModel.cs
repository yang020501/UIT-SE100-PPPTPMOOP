using household_management.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace household_management.ViewModel
{
    class PPVViewModel : BaseViewModel
    {
        DataTable dt;

        private string _txtName;
        public string txtName { get => _txtName; set { _txtName = value; OnPropertyChanged(); } }

        DataView dvPopulations;
        public DataView DvPopulations { get => dvPopulations; set { dvPopulations = value; OnPropertyChanged(); } }


        private ObservableCollection<Population> _PopulationsList;
        public ObservableCollection<Population> PopulationsList { get => _PopulationsList; set { _PopulationsList = value; OnPropertyChanged(); } }

        public PPVViewModel()
        {
            NewTablePopulations();
        }

        private Population _Selected;
        public Population Selected
        {
            get => _Selected;
            set 
            {
                _Selected = value;
                if(_Selected != null)
                {
                    _txtName = Selected.Name;
                }
            }
        }
        public void NewTablePopulations()
        {
            PopulationsList = new ObservableCollection<Population>(DataProvider.Ins.DB.Populations);
            dt = new DataTable();
            dt.Columns.Add("OrdinalNumber");
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Id_Household");
            dt.Columns.Add("PlaceOfBirth");
            dt.Columns.Add("Address");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Religion");
            dt.Columns.Add("Career");
            //fill datatable
            for (int i = 0; i < PopulationsList.Count; i++)
            {
                dt.Rows.Add
                    (
                         PopulationsList[i].Stt.ToString(),
                         PopulationsList[i].Id.ToString(),
                         PopulationsList[i].Name.ToString(),
                         PopulationsList[i].PlaceOfBirth.ToString(),
                         PopulationsList[i].DateOfBirth.ToString(),
                         PopulationsList[i].Sex.ToString(),
                         PopulationsList[i].Relegion.ToString(),
                         PopulationsList[i].Career.ToString()
                    );
            }
            dvPopulations = new DataView(dt);
        }
        public void doSearch(DataGrid dtg ,string find,string form)
        {
            form += " Like '%{0}%'";
            if (dvPopulations.Count < 0) // if nothing return 
                return;
            DvPopulations.RowFilter = string.Format(form, find);
            dtg.ItemsSource = DvPopulations;
            OnPropertyChanged("DvPopulations");

        }
    }
}
