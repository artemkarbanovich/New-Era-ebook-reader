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
using Ebook_Reader.Command;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;

namespace Ebook_Reader.ViewModel
{
    public class LibraryViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<Book> books = BookDB.GetBooksByLogin();
        private Book book;
        private string searchText = "";
        private string sortText;


        public ObservableCollection<Book> Books
        {
            get => books;
            set
            {
                books = value;
                RaisePropertiesChanged(nameof(Books));
            }
        }
        public Book Book
        {
            get => book;
            set
            {
                book = value;
                RaisePropertiesChanged(nameof(Book));
            }
        }
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                RaisePropertiesChanged(nameof(SearchText));
                RaisePropertiesChanged(nameof(FilteredBooks));
            }
        }
        public ObservableCollection<Book> FilteredBooks
        {
            get
            {
                if (sortText == null || sortText == "По умолчанию")
                {
                    var SelectedProducts = from b in Books
                                           where b.Name.ToLower().Contains(SearchText.ToLower())
                                           select b;
                    return new ObservableCollection<Book>(SelectedProducts);
                }
                else if (sortText == "По возрастанию")
                {
                    var SelectedProducts = from b in Books
                                           where b.Name.ToLower().Contains(SearchText.ToLower())
                                           orderby b.Name ascending
                                           select b;
                    return new ObservableCollection<Book>(SelectedProducts);
                }
                else if (sortText == "По убыванию")
                {
                    var SelectedProducts = from b in Books
                                           where b.Name.ToLower().Contains(SearchText.ToLower())
                                           orderby b.Name descending
                                           select b;
                    return new ObservableCollection<Book>(SelectedProducts);
                }
                else if (sortText == "Только txt файлы")
                {
                    var SelectedProducts = from b in Books
                                           where b.Name.ToLower().Contains(SearchText.ToLower())
                                           where b.BookFormat == "txt"
                                           select b;
                    return new ObservableCollection<Book>(SelectedProducts);
                }
                else if (sortText == "Только pdf файлы")
                {
                    var SelectedProducts = from b in Books
                                           where b.Name.ToLower().Contains(SearchText.ToLower())
                                           where b.BookFormat == "pdf"
                                           select b;
                    return new ObservableCollection<Book>(SelectedProducts);
                }
                else
                    return books;
            }
        }
        public string SortText
        {
            get => sortText;
            set
            {
                sortText = value;
                RaisePropertyChanged(nameof(SortText));
                RaisePropertiesChanged(nameof(FilteredBooks));
            }
        }
        #endregion


        #region Commands
        public ICommand addBookToLibrary => new DelegateCommand(AddBookToLibrary);
        private void AddBookToLibrary()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Book files | *.txt; *.pdf;";

            if (dialog.ShowDialog().GetValueOrDefault(false))
            {
                string pathUserBook = @"..\..\Users\" + ActiveUser.User.Login + @"\" + dialog.SafeFileName;
                string pathBook = dialog.FileName;
                try
                {
                    FileInfo fileInf = new FileInfo(pathBook);
                    if (fileInf.Exists)
                        fileInf.CopyTo(pathUserBook, true);
                }
                catch { }


                Book book = new Book(ActiveUser.User.Login, dialog.SafeFileName.Remove(dialog.SafeFileName.Length - 4), pathUserBook, 1);
                BookHistory bookHistory = new BookHistory(book.Login, book.Name, book.RelativePath);

                if (Book.AddBookToDB(book, bookHistory, ActiveUser.User) == true)
                {                
                    MessageBox.Show($"Книга {dialog.SafeFileName.Remove(dialog.SafeFileName.Length - 4)} успешно добавлена в библиотеку.", "Оповещение");
                    Books.Add(book);
                    SearchText += "";
                }
            }
        }

        public ICommand deleteBookFromLibrary => new DelegateCommand(DeleteBookFromLibrary);
        private void DeleteBookFromLibrary()
        {
            if (Book != null)
            {
                MessageBoxResult result = MessageBox.Show($"Вы уверены что хотите удалить { Book.Name } ?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        FileInfo fileInf = new FileInfo(Book.RelativePath);
                        if (fileInf.Exists)
                            fileInf.Delete();
                    }
                    catch { }

                    if (Book.DeleteBookFromDB(Book) == true)
                    {
                        Books.Remove(Book);
                        SearchText += "";
                    }
                }
            }
        }
    
        public ICommand openDocumentReader => new DelegateCommand(OpenDocumentReader);
        private void OpenDocumentReader()
        {
            if (Book.BookFormat == "txt")
                MainWindowDataContext.DataContext.SelectedViewModel = new TxtViewModel(Book);
            else if (Book.BookFormat == "pdf")
                MainWindowDataContext.DataContext.SelectedViewModel = new PdfViewModel(Book);
        }
        #endregion
    }
}
