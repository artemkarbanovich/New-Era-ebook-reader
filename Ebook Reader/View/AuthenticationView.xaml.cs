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
using Ebook_Reader.ViewModel;

namespace Ebook_Reader.View
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationView.xaml
    /// </summary>
    public partial class AuthenticationView : Window
    {
        AuthenticationViewModel avm = new AuthenticationViewModel();
        public AuthenticationView()
        {
            InitializeComponent();
            DataContext = avm;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) => avm.SetPassword((sender as PasswordBox).SecurePassword);
    }
}
