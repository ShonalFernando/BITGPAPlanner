﻿using Planner.Client.ViewModel;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planner.Client.View.Pages
{
    /// <summary>
    /// Interaction logic for CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        GPACalculator _gpaCalculator;

        public CalculatorPage()
        {
            InitializeComponent();
            _gpaCalculator = new();
            DataContext = _gpaCalculator;
        }

        private void SubjectSelected(object sender, SelectionChangedEventArgs e)
            => _gpaCalculator.SubjectCheckTrigger();
    }
}
