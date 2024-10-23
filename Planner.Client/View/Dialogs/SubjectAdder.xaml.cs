using MahApps.Metro.Controls;
using Planner.Client.ViewModel;
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

namespace Planner.Client.View.Dialogs
{
    /// <summary>
    /// Interaction logic for SubjectAdder.xaml
    /// </summary>
    public partial class SubjectAdder : MetroWindow
    {
        public SubjectAdder()
        {
            InitializeComponent();
            SubjectCreator _subjectCreator = new();
            DataContext = _subjectCreator;
        }
    }
}
