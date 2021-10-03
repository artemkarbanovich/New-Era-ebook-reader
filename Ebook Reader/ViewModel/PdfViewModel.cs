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
using Microsoft.Win32;
using Ebook_Reader.DataBase;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Ebook_Reader.ViewModel
{
    public class PdfViewModel : ViewModelBase
    {
        #region Properties
        private Book book;
        private string pathToFile;
        private DateTime startReading;


        public string PathToFile
        {
            get => pathToFile;
            set
            {
                pathToFile = value;
                RaisePropertyChanged(nameof(PathToFile));
            }
        }


        public PdfViewModel(Book book)
        {
            this.book = book;
            PathToFile = book.RelativePath;
            startReading = DateTime.Now;
        }
        #endregion


        #region Commands
        public ICommand stopRead => new DelegateCommand(StopRead);
        private void StopRead()
        {
            Statistics stat = new Statistics(ActiveUser.User.Login, book.Name, "pdf", DateTime.Now, DateTime.Now.Subtract(startReading));
            Statistics.SaveStatisticsDB(stat);

            MainWindowDataContext.DataContext.SelectedViewModel = new LibraryViewModel();
        }
        #endregion
    }
}
