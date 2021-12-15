﻿using household_management.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace household_management.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private ViewModel.SearchViewModel searchView = new ViewModel.SearchViewModel();
        List<RadioButton> radioButtons = new List<RadioButton>();
        public Search()
        {
            InitializeComponent();
            if (selected.SelectedIndex != 0)
            {
               
            }
        }




        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void selected_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Search view = new Search();
            view.ShowDialog();
            Close();
            MessageBox.Show("Nug");
        }

        private void selected_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Search view = new Search();
            view.ShowDialog();
            Close();
            MessageBox.Show("Nug");
        }
    }
}
