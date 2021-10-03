using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Ebook_Reader.Model
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection") { }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookHistory> BooksHistory { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
    }
}
