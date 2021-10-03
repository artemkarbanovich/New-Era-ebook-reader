using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using Ebook_Reader.View;
using System.ComponentModel;
using System.Security;
using System.Runtime.InteropServices;
using Ebook_Reader.Model;
using Ebook_Reader.DataBase;
using System.Security.Cryptography;
using System.IO;
using Ebook_Reader.Model.Password;

namespace Ebook_Reader.ViewModel
{
    class RegistrationViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        private string login;
        private string firstName;
        private string secondName;
        private SecureString password = new SecureString();
        private SecureString repeatPassword = new SecureString();
        private string notificationText = "";
        private string notificationColor = "black";


        public string Login
        {
            get => login;
            set
            {
                login = value;
                RaisePropertiesChanged(nameof(Login));
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                RaisePropertiesChanged(nameof(FirstName));
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                RaisePropertiesChanged(nameof(SecondName));
            }
        }
        public string NotificationText
        {
            get => notificationText;
            set
            {
                notificationText = value;
                RaisePropertiesChanged(nameof(NotificationText));
            }
        }
        public string NotificationColor
        {
            get => notificationColor;
            set
            {
                notificationColor = value;
                RaisePropertiesChanged(nameof(NotificationColor));
            }
        }
        #endregion


        #region Validation
        public string Error { get => null; }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Login":
                        if (string.IsNullOrWhiteSpace(Login))
                            result = "Логин не может быть пустым";
                        else if (Login.Length < 5 || Login.Length > 22)
                            result = "Длина логина должна быть от 5 до 22 символов";
                        else if (Login.Contains(" "))
                            result = "Логин не может содержать пробелов";
                        break;

                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                            result = "Имя не может быть пустым";
                        else if (FirstName.Length < 2 || FirstName.Length > 25)
                            result = "Длина имени должна быть от 2 до 25 символов";
                        break;

                    case "SecondName":
                        if (string.IsNullOrWhiteSpace(SecondName))
                            result = "Фамилия не может быть пустым";
                        else if (SecondName.Length < 2 || SecondName.Length > 25)
                            result = "Длина фамилии должна быть от 2 до 25 символов";
                        break;

                    case "PasswordExtra":
                        if (password.Length == 0)
                            result = "Пароль не может быть пустым";
                        else if (password.Length < 8 || password.Length > 22)
                            result = "Длина пароля должна быть от 8 до 22 символов";
                        break;

                    case "RepeatPasswordExtra":
                        if (PasswordHelper.PasswordEqual(password, repeatPassword) == false)
                            result = "Пароли должны совпадать";
                        else if (repeatPassword.Length == 0)
                            result = "Повторите пароль";
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = result;
                else if (result != null)
                    ErrorCollection.Add(columnName, result);
                RaisePropertiesChanged(nameof(ErrorCollection));

                return result;
            }
        }

        public bool PasswordExtra { get => false; }
        public bool RepeatPasswordExtra { get => false; }

        public void SetPassword(SecureString pwd)
        {
            password = pwd.Copy();
            password.MakeReadOnly();
            RaisePropertiesChanged(nameof(PasswordExtra));
        }
        public void SetRepeatPassword(SecureString pwd)
        {
            repeatPassword = pwd.Copy();
            repeatPassword.MakeReadOnly();
            RaisePropertiesChanged(nameof(RepeatPasswordExtra));
        }


        private bool IsValid()
        {
            if (this["Login"] != null)
                return false;
            if (this["FirstName"] != null)
                return false;
            if (this["SecondName"] != null)
                return false;
            if (this["PasswordExtra"] != null)
                return false;
            if (this["RepeatPasswordExtra"] != null)
                return false;
            if (UserDB.CheckLogin(Login) == false)
            {
                NotificationText = "Такой логин уже существует. Подберите другой";
                NotificationColor = "OrangeRed";
                return false;
            }

            return true;
        }
        #endregion


        #region Methods
        private void CloseRegistrationWindow()
        {
            foreach (Window w in App.Current.Windows)
                if (w.DataContext == this)
                    w.Close();
        }
        #endregion


        #region Commands
        public ICommand signInWindow => new DelegateCommand(SignInWindow);
        private void SignInWindow()
        {
            AuthenticationView av = new AuthenticationView();
            av.Show();
            CloseRegistrationWindow();
        }

        public ICommand signUp => new DelegateCommand(SignUp);
        private void SignUp()
        {
            if (IsValid() == true)
            {                
                User user = new User(Login.ToLower(), FirstName, SecondName, HasherBytes.HashBytes(PasswordHelper.HashPassword(repeatPassword, new SingleByteXor())));
                User.CreateUserDB(user);

                string path = @"..\..\Users\" + user.Login;
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                NotificationText = "Аккаунт успешно создан";
                NotificationColor = "DarkGreen";
            }
        }
        #endregion
    }
}
