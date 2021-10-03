using DevExpress.Mvvm;
using Ebook_Reader.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Ebook_Reader.View;


namespace Ebook_Reader.ViewModel
{
    public class TxtViewModel : ViewModelBase
    {
        #region Properties and Constructors
        private Book book;
        private string bookText;
        private DateTime startReading;
        private static int bookmark;


        public Book Book
        {
            get => book;
            set => book = value;
        }
        public string BookText
        {
            get => bookText;
            set
            {
                bookText = value;
                RaisePropertyChanged(BookText);
            }
        }
        public int Bookmark
        {
            get => bookmark;
            set => bookmark = value;
        }


        public TxtViewModel(Book book)
        {
            Book = book;
            BookText = File.ReadAllText(book.RelativePath);
            startReading = DateTime.Now;
            bookmark = book.PageBookmark;
        }
        #endregion


        #region Methods
        public static int GetPageBookmark() => bookmark;
        #endregion


        #region Commands
        public ICommand stopRead => new DelegateCommand(StopRead);
        private void StopRead()
        {
            Statistics stat = new Statistics(ActiveUser.User.Login, Book.Name, "txt", DateTime.Now, DateTime.Now.Subtract(startReading));
            Statistics.SaveStatisticsDB(stat);

            Book.UpdatePageBookmarkDB(Book);

            MainWindowDataContext.DataContext.SelectedViewModel = new LibraryViewModel();
        }
        #endregion
    }
}
