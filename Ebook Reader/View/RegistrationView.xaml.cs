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
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        RegistrationViewModel rvm = new RegistrationViewModel();
        public RegistrationView()
        {
            InitializeComponent();
            DataContext = rvm;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) => rvm.SetPassword((sender as PasswordBox).SecurePassword);
        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e) => rvm.SetRepeatPassword((sender as PasswordBox).SecurePassword);
    }
}
