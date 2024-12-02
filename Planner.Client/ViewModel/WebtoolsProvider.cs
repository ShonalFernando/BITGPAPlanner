using Microsoft.Web.WebView2.Wpf;
using Planner.Client.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Planner.Client.ViewModel
{
    internal class WebtoolsProvider : ViewModelBase
    {
        // Private Fields --------------------------> Data
        private string _locator = null!;

        // Fields --------------------------> User Interface
        private bool _isGoBackEnable;
        private bool _isGoForwardEnable;
        private bool _isVLEEnable;
        private bool _isSiteEnable;


        // Commands
        public ICommand Open_CboardCommand { get; }

        public WebtoolsProvider()
        {
            IsGoBackEnable = false;
            IsGoForwardEnable = false;
            IsVLEEnable = false;
            IsSiteEnable = true;
        }

        // Properties
        public bool IsGoBackEnable
        {
            get => _isGoBackEnable;
            set
            {
                _isGoBackEnable = value;
                OnPropertyChanged(); // Notify UI of change
            }
        }

        public bool IsGoForwardEnable
        {
            get => _isGoForwardEnable;
            set
            {
                _isGoForwardEnable = value;
                OnPropertyChanged();
            }
        }

        public bool IsVLEEnable
        {
            get => _isVLEEnable;
            set
            {
                _isVLEEnable = value;
                OnPropertyChanged();
            }
        }

        public bool IsSiteEnable
        {
            get => _isSiteEnable;
            set
            {
                _isSiteEnable = value;
                OnPropertyChanged();
            }
        }
    }
}