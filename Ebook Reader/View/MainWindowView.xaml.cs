﻿using System;
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
using Ebook_Reader.Model;
using Ebook_Reader.ViewModel;

namespace Ebook_Reader.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView(User user)
        {
            ActiveUser.User = user;
            InitializeComponent();
            MainWindowViewModel mwvm = new MainWindowViewModel(user);
            DataContext = mwvm;
            MainWindowDataContext.DataContext = mwvm;
        }
    }
}
