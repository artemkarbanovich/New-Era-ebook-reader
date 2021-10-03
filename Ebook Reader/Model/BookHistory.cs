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
    public class BookHistory : BookHistoryDB
    {
        private string login;
        private string name;
        private DateTime dateAdded;
        private List<User> users = new List<User>();
        private string bookFormat;


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


        public BookHistory(string login, string name, string relativePath)
        {
            Login = login;
            Name = name;
            DateAdded = DateTime.Now;
            BookFormat = relativePath.Substring(relativePath.Length - 3);
        }
        public BookHistory() { }
    }
}
