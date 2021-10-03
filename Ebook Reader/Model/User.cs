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
    public class User : UserDB
    {
        private string login;
        private string firstName;
        private string secondName;
        private DateTime registrationDate;
        private byte[] password;
        private Settings userSettings;
        private List<Book> books = new List<Book>();
        private List<BookHistory> booksHistory = new List<BookHistory>();
        private List<Statistics> statistics = new List<Statistics>();


        public int Id { get; set; }
        [Key]
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }
        public string SecondName
        {
            get => secondName;
            set => secondName = value;
        }
        public DateTime RegistrationDate
        {
            get => registrationDate;
            set => registrationDate = value;
        }
        public byte[] Password
        {
            get => password;
            set => password = value;
        }
        public Settings UserSettings
        {
            get => userSettings;
            set => userSettings = value;
        }
        public List<Book> Books
        {
            get => books;
            set => books = value;
        }
        public List<BookHistory> BooksHistory
        {
            get => booksHistory;
            set => booksHistory = value;
        }
        public List<Statistics> Statistics
        {
            get => statistics;
            set => statistics = value;
        }


        public User(string login, string firstName, string secondName, byte[] password)
        {
            Login = login;
            FirstName = firstName;
            SecondName = secondName;
            RegistrationDate = DateTime.Now;
            Password = password;
        }
        public User(string login, byte[] password)
        {
            Login = login;
            Password = password;
        }
        public User() { }


        public static void CreateUserDB(User user) => UserDB.CreateUser(user);
        public static void DeleteAccountDB() => UserDB.DeleteAccount();
    }
}
