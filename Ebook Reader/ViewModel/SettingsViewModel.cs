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
using System.Collections.ObjectModel;
using System.IO;

namespace Ebook_Reader.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Properties and Constructors
        private Settings settings = SettingsDB.GetSettingsByLogin();
        private string theme;
        private string fontStyle;
        private string currentFontStyle;
        private string currentTheme;
        private string currentLanguage;
        public User currentUser;
        
        
        public string Theme
        {
            get => theme;
            set
            {
                theme = value;
                RaisePropertyChanged(nameof(Theme));
            }
        }
        public string FontStyle
        {
            get => fontStyle;
            set
            {
                fontStyle = value;
                RaisePropertyChanged(nameof(FontStyle));
            }
        }
        public string CurrentFontStyle
        {
            get => currentFontStyle;
            set
            {
                currentFontStyle = value;
                RaisePropertyChanged(nameof(CurrentFontStyle));
            }
        }
        public string CurrentTheme
        {
            get => currentTheme;
            set
            {
                currentTheme = value;
                RaisePropertyChanged(nameof(CurrentTheme));
            }
        }
        public string CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                currentLanguage = value;
                RaisePropertyChanged(nameof(CurrentLanguage));
            }
        }
        public string CurrentUserLogin { get => ActiveUser.User.Login; }
        public string CurrentUserFirstName { get => ActiveUser.User.FirstName; }
        public string CurrentUserSecondName { get => ActiveUser.User.SecondName; }
        public DateTime CurrentUserRegistrationDate { get => ActiveUser.User.RegistrationDate; }


        public SettingsViewModel()
        {
            CurrentTheme = settings.Theme;
            CurrentFontStyle = settings.FontStyle;
            CurrentLanguage = settings.Language;
        }
        #endregion

        
        #region Commands
        public ICommand saveSettings => new DelegateCommand(SaveSettings);
        private void SaveSettings()
        {
            if(Theme != null)
            {
                CurrentTheme = Theme;
                string pathToTheme = null;

                if (Theme == "Стандартная")
                    pathToTheme = "../Theme/GreenTheme.xaml";
                else if (Theme == "Темная")
                    pathToTheme = "../Theme/DarkTheme.xaml";

                var uri = new Uri(pathToTheme, UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

                settings = SettingsDB.GetSettingsByLogin();
                if (Theme != settings.Theme)
                    Settings.ChangeThemeDB(Theme);
            }
            if(FontStyle != null)
            {
                CurrentFontStyle = FontStyle;
                string pathToFontFamily = null;

                if (FontStyle == "Courier New")
                    pathToFontFamily = "../Theme/Fonts/CourierNew.xaml";
                else if (FontStyle == "Corbel")
                    pathToFontFamily = "../Theme/Fonts/Corbel.xaml";
                else if (FontStyle == "Segoe Print")
                    pathToFontFamily = "../Theme/Fonts/SegoePrint.xaml";
                else if (FontStyle == "Segoe UI")
                    pathToFontFamily = "../Theme/Fonts/SegoeUI.xaml";
                else if (FontStyle == "Verdana")
                    pathToFontFamily = "../Theme/Fonts/Verdana.xaml";

                var uri = new Uri(pathToFontFamily, UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

                settings = SettingsDB.GetSettingsByLogin();
                if (FontStyle != settings.FontStyle)
                    Settings.ChangeFontStyleDB(FontStyle);
            }
        }

        public ICommand deleteAccount => new DelegateCommand(DeleteAccount);
        private void DeleteAccount()
        {
            MessageBoxResult result = MessageBox.Show($"Вы уверены что хотите удалить текущий аккаунт? После удаления аккаунт восстановлению не подлежит!",
                "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    string userDirToDelete = @"..\..\Users\" + ActiveUser.User.Login.ToLower();
                    DirectoryInfo dirInfo = new DirectoryInfo(userDirToDelete);
                    dirInfo.Delete(true);
                }
                catch { }
                User.DeleteAccountDB();

                MessageBox.Show("Аккаунт успешно удален.", "Оповещение");

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
        #endregion
    }
}
