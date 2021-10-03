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
    public class Statistics : StatisticsDB
    {
        private string login;
        private string bookName;
        private string bookFormat;
        private DateTime currentDate;
        private TimeSpan readTime;


        [Key]
        public int Id { get; set; }
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string BookName
        {
            get => bookName;
            set => bookName = value;
        }
        public string BookFormat
        {
            get => bookFormat;
            set => bookFormat = value;
        }
        public DateTime CurrentDate
        {
            get => currentDate;
            set => currentDate = value;
        }
        public TimeSpan ReadTime
        {
            get => readTime;
            set => readTime = value;
        }
        public User User { get; set; }


        public Statistics(string login, string bookName, string bookFormat, DateTime currentDate, TimeSpan readTime)
        {
            Login = login;
            BookName = bookName;
            BookFormat = bookFormat;
            CurrentDate = currentDate;
            ReadTime = readTime;
        }
        public Statistics() { }


        public static void SaveStatisticsDB(Statistics stat) => StatisticsDB.SaveStatistics(stat);
    }
}
