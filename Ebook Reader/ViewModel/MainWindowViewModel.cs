using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows;
using Ebook_Reader.View;
using System.Windows.Input;
using Ebook_Reader.Model;
using System.ComponentModel;
using System.Security;
using Ebook_Reader.DataBase;
using Ebook_Reader.ViewModel;
using Ebook_Reader.Command;

namespace Ebook_Reader.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties and Constructors
        private User user;


        public User User
        {
            get => user;
            set => user = value;
        }


        public MainWindowViewModel(User user)
        {
            Settings settings = SettingsDB.GetSettingsByLogin();
            string pathToTheme = null;

            if (settings.Theme == "Стандартная")
                pathToTheme = "../Theme/GreenTheme.xaml";
            else if(settings.Theme == "Темная")
                pathToTheme = "../Theme/DarkTheme.xaml";

            var uri = new Uri(pathToTheme, UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);


            string pathToFontFamily = null;

            if (settings.FontStyle == "Courier New")
                pathToFontFamily = "../Theme/Fonts/CourierNew.xaml";
            else if (settings.FontStyle == "Corbel")
                pathToFontFamily = "../Theme/Fonts/Corbel.xaml";
            else if (settings.FontStyle == "Segoe Print")
                pathToFontFamily = "../Theme/Fonts/SegoePrint.xaml";
            else if (settings.FontStyle == "Segoe UI")
                pathToFontFamily = "../Theme/Fonts/SegoeUI.xaml";
            else if (settings.FontStyle == "Verdana")
                pathToFontFamily = "../Theme/Fonts/Verdana.xaml";

            uri = new Uri(pathToFontFamily, UriKind.Relative);
            resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);


            User = user;
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        #endregion


        #region Navigation
        private static ViewModelBase selectedViewModel = new LibraryViewModel();
        public ViewModelBase SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }
        #endregion
        

        #region Commands
        public ICommand logOut => new DelegateCommand(LogOut);
        private void LogOut()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        public ICommand UpdateViewCommand { get; set; }


        public ICommand aboutProgram => new DelegateCommand(AboutProgram);
        private void AboutProgram()
        {
            MessageBox.Show($"Приложение: New Era ebook reader\n" +
                $"Версия: 1.0.5\n" +
                $"Разработчик: Карбанович Артём Константинович\n", "О программе");
        }
        #endregion
    }
}
