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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ebook_Reader.ViewModel;

namespace Ebook_Reader.View
{
    /// <summary>
    /// Логика взаимодействия для TxtView.xaml
    /// </summary>
    public partial class TxtView : UserControl
    {
        private static FlowDocumentPageViewer fdpv;
        public TxtView()
        {
            InitializeComponent();
            fdpv = TxtDocumentReader;
        }

        public static int GetCurrentPageBookmark() => fdpv.MasterPageNumber;
        private void Button_Click(object sender, RoutedEventArgs e) => fdpv.GoToPage(TxtViewModel.GetPageBookmark());
    }
}
