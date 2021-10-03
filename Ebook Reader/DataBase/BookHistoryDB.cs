using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebook_Reader.Model;
using System.Windows;
using System.Collections.ObjectModel;

namespace Ebook_Reader.DataBase
{
    public class BookHistoryDB
    {
        public static void GetStatTotalBooksLibrary(ref int countBooks, ref int countTxt, ref int countPdf)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    countBooks = context.BooksHistory.Count(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower());
                    countTxt = context.BooksHistory.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()).Where(b => b.BookFormat.ToLower() == "txt").Count();
                    countPdf = context.BooksHistory.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()).Where(b => b.BookFormat.ToLower() == "pdf").Count();
                }
            }
            catch { }
        }
    }
}
