using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ebook_Reader.DataBase;

namespace Ebook_Reader.Model
{
    public class Book : BookDB
    {
        private string login;
        private string name;
        private string relativePath;
        private DateTime dateAdded;
        private List<User> users = new List<User>();
        private string bookFormat;
        private int pageBookmark;


        [Key]
        public int Id { get; set; }
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public DateTime DateAdded
        {
            get => dateAdded;
            set => dateAdded = value;
        }
        public string RelativePath
        {
            get => relativePath;
            set => relativePath = value;
        }
        public string BookFormat
        {
            get => bookFormat;
            set => bookFormat = value;
        }
        public List<User> Users 
        {
            get => users;
            set => users = value;
        }
        public int PageBookmark
        {
            get => pageBookmark;
            set => pageBookmark = value;
        }


        public Book(string login, string name, string relativePath, int pageBookmark)
        {
            Login = login;
            Name = name;
            RelativePath = relativePath;
            DateAdded = DateTime.Now;
            BookFormat = relativePath.Substring(relativePath.Length - 3);
            PageBookmark = pageBookmark;
        }
        public Book() { }


        public static bool AddBookToDB(Book book, BookHistory bookHistory, User user) => BookDB.AddBook(book, bookHistory, user);
        public static bool DeleteBookFromDB(Book book) => BookDB.DeleteBook(book);
        public static void UpdatePageBookmarkDB(Book bookUpdate) => BookDB.UpdatePageBookmark(bookUpdate);
    } 
}
