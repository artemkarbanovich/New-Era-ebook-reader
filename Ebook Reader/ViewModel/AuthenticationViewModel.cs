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
using Ebook_Reader.Model.Password;

namespace Ebook_Reader.ViewModel
{
    public class AuthenticationViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        private string login;
        private SecureString password = new SecureString();
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

                    case "PasswordExtra":
                        if (password.Length == 0)
                            result = "Пароль не может быть пустым";
                        else if (password.Length < 8 || password.Length > 22)
                            result = "Длина пароля должна быть от 8 до 22 символов";
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

        public void SetPassword(SecureString pwd)
        {
            password = pwd.Copy();
            password.MakeReadOnly();
            RaisePropertiesChanged(nameof(PasswordExtra));
        }


        private bool IsValid()
        {
            if (this["Login"] != null)
                return false;
            if (this["PasswordExtra"] != null)
                return false;

            return true;
        }
        #endregion


        #region Methods
        private void CloseAuthenticationWindow()
        {
            foreach (Window w in App.Current.Windows) 
                if (w.DataContext == this) 
                    w.Close();
        }
        #endregion


        #region Commands
        public ICommand signIn => new DelegateCommand(SignIn);
        private void SignIn()
        {
            if(IsValid() == true)
            {
                if (UserDB.CheckLogin(Login) == false)
                {
                    User user = UserDB.ReturnUserByLogin(Login);
                    byte[] hashPassword = PasswordHelper.HashPassword(password, new SingleByteXor());

                    if (user.Password.SequenceEqual(HasherBytes.HashBytes(hashPassword)) == true)
                    {
                        MainWindowView sp = new MainWindowView(user);
                        sp.Show();
                        CloseAuthenticationWindow();
                    }
                    else
                    {
                        NotificationText = "Проверьте введенный пароль";
                        NotificationColor = "OrangeRed";
                    }
                }
                else
                {
                    NotificationText = "Такого пользователя не существует";
                    NotificationColor = "OrangeRed";
                }
            }
        }
        
        public ICommand signUpWindow => new DelegateCommand(SignUpWindow);
        private void SignUpWindow()
        {
            RegistrationView rv = new RegistrationView();
            rv.Show();
            CloseAuthenticationWindow();
        }
        #endregion
    }
}
