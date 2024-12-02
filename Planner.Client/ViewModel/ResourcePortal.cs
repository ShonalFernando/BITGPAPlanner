using Planner.Client.Command;
using Planner.Client.Helper;
using Planner.Client.ObservableModel;
using Planner.Client.View.Dialogs;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using UnitTester.Session;

namespace Planner.Client.ViewModel
{
    internal class ResourcePortal : ViewModelBase
    {
        // Private Fields
        private int _level;
        private bool _allLevels;
        private Subject? _selectedSubject;

        // Private Fields -----> Helper
        private string LastAccessedSubFolder;
        private string FileTypes;


        // public Fields
        public ObservableCollection<FileItem> FileItems { get; set; }
        private ObservableCollection<Subject> _subjects;

        // Properties

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        public bool IsAllLevels
        {
            get => _allLevels;
            set
            {
                _allLevels = value;
                OnPropertyChanged();
            }
        }

        public Subject? SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }


        // Commands
        public ICommand LoadPPCommand { get; }
        public ICommand LoadSNotesCommand { get; }
        public ICommand LoadARandomCommand { get; }
        public ICommand LoadRecieptSCommand { get; }
        public ICommand LoadRefCommand { get; }
        public ICommand LoadAVideosCommand { get; }
        public ICommand FilterLoadCommand { get; }
        public ICommand AddCopyFilesCommand { get; }
        public ICommand SearchSubjectsCommand { get; }


        // Constructor
        public ResourcePortal()
        {
            // Set All Semesters to True at start
            IsAllLevels = false;
            Level = 5; // This should get the default by settings
            LastAccessedSubFolder = "";
            FileTypes = "";

            // Populate Subjects 
            Subjects = new ObservableCollection<Subject>(Subject.GetSubjectsByLevel(AppSession.ConnectionString,Level));

            // Initialize Commands
            FileItems = new ObservableCollection<FileItem>();

            LoadPPCommand = new RelayCommand(_ => LoadFiles(Level,"Past Papers", false));
            LoadSNotesCommand = new RelayCommand(_ => LoadFiles(Level, "Notes", false));
            LoadARandomCommand = new RelayCommand(_ => LoadFiles(Level, "Random", false));
            LoadRecieptSCommand = new RelayCommand(_ => LoadFiles(Level, "Reciepts", false));
            LoadRefCommand = new RelayCommand(_ => LoadFiles(Level, "Reference Books", false));
            LoadAVideosCommand = new RelayCommand(_ => LoadFiles(Level, "Videos", false));

            FilterLoadCommand = new RelayCommand(_ => Filter());
            SearchSubjectsCommand = new RelayCommand(_ => PopulateSubjects());

            AddCopyFilesCommand = new RelayCommand(_ => IOHelper.LoadFiles());

            // Testing Only
            //AppFirstInitializer.InitializeFolders();
        }

        // Other Methods
        private void LoadFiles(int inLevel , string subFolder, bool isItterated)
        {
            FileItems.Clear();

            if (SelectedSubject != null)
            {
                string targetPath = Path.Combine(IOHelper.BasePath, "BITVA Docs", SelectedSubject.SubjectCode, subFolder);

                if (!Directory.Exists(targetPath))
                    return;

                if (!isItterated)
                {
                    // Clear any existing items
                    FileItems.Clear();
                }

                // Get all files in the folder (customize as needed)
                string[] files = Directory.GetFiles(targetPath);

                foreach (var filePath in files)
                {
                    FileItems.Add(new FileItem(filePath));
                }

                LastAccessedSubFolder = subFolder;
                FileTypes = IOHelper.GetFileTypesBySubFolder(subFolder);
            } 
        }

        // Populate Subjects
        private void PopulateSubjects()
        {
            Subjects.Clear();
            var AllSubjects = Subject.GetAllSubjects(AppSession.ConnectionString);

            Subjects = new ObservableCollection<Subject>(AllSubjects.FindAll(sub => sub.Level.Equals(Level))); 
        }

        // Need to Refactor this is wrong
        private void Filter()
        {
            // not Implimented
        }
    }
}
