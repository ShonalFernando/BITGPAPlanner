﻿using MahApps.Metro.Controls;
using Planner.Client.Helper;
using Planner.Client.ObservableModel;
using Planner.Client.Services;
using Planner.Client.View.Pages;
using Planner.Client.ViewModel;
using Planner.Model;
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
using System.Windows.Shapes;
using UnitTester.Session;

namespace Planner.Client.View
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow()
        {
            InitializeComponent();

            ShellController ShellController = new();
            DataContext = ShellController;

            TestUtlity.ExecuteProductionCode(() => { DataInitializors.InitializeDatabase(); });

            PageFrameHolder.ReloadTransition();
        }
    }
}
