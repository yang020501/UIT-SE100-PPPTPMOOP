﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for Household.xaml
    /// </summary>
    public partial class Household : Window
    {
        public Household()
        {
            InitializeComponent();
            tbFullName.Focus();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
    
        }

        
    }
}
