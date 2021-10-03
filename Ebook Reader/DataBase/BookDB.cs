using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebook_Reader.Model;
using System.Windows;
using System.Collections.ObjectModel;
using Ebook_Reader.View;

namespace Ebook_Reader.DataBase
{
    public class BookDB
    {
        private protected static bool AddBook(Book book, BookHistory bookHistory, User user)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    int checkBook = context.Books.Where(b => b.Login == book.Login).Where(b => b.Name == book.Name).Where(b => b.BookFormat == book.BookFormat).Count();

                    if (checkBook == 0)
                    {
                        user.Books.Add(book);
                        context.Books.Add(book);
                        context.SaveChanges();
                        AddBookHistory(bookHistory, user);
                        return true;
                    }
                    else
                        MessageBox.Show($"У пользователя {user.Login} уже есть книга под названием {book.Name}.\nВыберите другую.", "Оповещение");
                    return false;
                }
            }
            catch { return false; }
        }

        private static void AddBookHistory(BookHistory book, User user)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    var checkBook = context.BooksHistory.Where(b => b.Login == book.Login).Where(b => b.Name == book.Name).Where(b => b.BookFormat == book.BookFormat);

                    if (checkBook.Count() == 0)
                    {
                        user.BooksHistory.Add(book);
                        context.BooksHistory.Add(book);
                        context.SaveChanges();
                    }
                }
            }
            catch { }
        }

        private protected static bool DeleteBook(Book book)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    Book bookDel = context.Books.Where(b => b.Login == ActiveUser.User.Login).Where(b => b.Name == book.Name).FirstOrDefault();

                    if (bookDel != null)
                    {
                        context.Books.Remove(bookDel);
                        context.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch { return false; }
        }

        public static ObservableCollection<Book> GetBooksByLogin()
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    var books = from b in context.Books
                                where b.Login.ToLower() == ActiveUser.User.Login.ToLower()
                                select b;
                    return new ObservableCollection<Book>(books);
                }
            }
            catch { return new ObservableCollection<Book>(); }
        }

        public static void GetStatBooksLibrary(ref int countBooks, ref int countTxt, ref int countPdf)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    countBooks = context.Books.Count(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower());
                    countTxt = context.Books.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()).Where(b => b.BookFormat.ToLower() == "txt").Count();
                    countPdf = context.Books.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()).Where(b => b.BookFormat.ToLower() == "pdf").Count();
                }
            }
            catch { }
        }

        private protected static void UpdatePageBookmark(Book bookUpdate)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    Book book = context.Books
                                .Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower())
                                .Where(b => b.Name.ToLower() == bookUpdate.Name.ToLower())
                                .Where(b => b.BookFormat.ToLower() == bookUpdate.BookFormat.ToLower())
                                .FirstOrDefault();

                    book.PageBookmark = TxtView.GetCurrentPageBookmark();
                    context.SaveChanges();
                }
            }
            catch { }
        }
    }
}
