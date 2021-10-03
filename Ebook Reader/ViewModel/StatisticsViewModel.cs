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
using Ebook_Reader.DataBase;

namespace Ebook_Reader.ViewModel
{
    public class StatisticsViewModel : ViewModelBase
    {
        #region Properties and Constructors

        #region Books in library
        private int countBooks;
        private int txtCountBooks;
        private int pdfCountBooks;


        public int CountBooks { get => countBooks; }
        public int CountBooksPercent
        {
            get
            {
                if (CountBooks > 0)
                    return 100;
                else
                    return 0;
            }
        }
        public int TxtCountBooks { get => txtCountBooks; }
        public double TxtCountBooksPercent
        {
            get
            {
                if (TxtCountBooks > 0)
                    return Math.Round(((double)TxtCountBooks * 100.0 / (double)CountBooks), 2);
                else
                    return 0;
            }
        }
        public int PdfCountBooks { get => pdfCountBooks; }
        public double PdfCountBooksPercent
        {
            get
            {
                if (PdfCountBooks > 0)
                    return Math.Round(((double)PdfCountBooks * 100.0 / (double)CountBooks), 2);
                else
                    return 0;
            }
        }
        #endregion

        #region Total books
        private int countTotalBooks;
        private int txtTotalCountBooks;
        private int pdfTotalCountBooks;


        public int TotalCountBooks { get => countTotalBooks; }
        public int TotalCountBooksPercent
        {
            get
            {
                if (TotalCountBooks > 0)
                    return 100;
                else
                    return 0;
            }
        }
        public int TxtTotalCountBooks { get => txtTotalCountBooks; }
        public double TxtTotalCountBooksPercent
        {
            get
            {
                if (TxtTotalCountBooks > 0)
                    return Math.Round(((double)TxtTotalCountBooks * 100.0 / (double)TotalCountBooks), 2);
                else
                    return 0;
            }
        }
        public int PdfTotalCountBooks { get => pdfTotalCountBooks; }
        public double PdfTotalCountBooksPercent
        {
            get
            {
                if (PdfTotalCountBooks > 0)
                    return Math.Round(((double)PdfTotalCountBooks * 100.0 / (double)TotalCountBooks), 2);
                else
                    return 0;
            }
        }
        #endregion

        #region Read statistics by time
        private TimeSpan readToday;
        private TimeSpan readWeek;
        private TimeSpan readMonth;
        private TimeSpan readYear;
        private TimeSpan readAllTime;
        private List<Statistics> dailyStatistics; 
        private Statistics statistics;


        public TimeSpan ReadToday { get => readToday; }
        public TimeSpan ReadWeek { get => readWeek; }
        public TimeSpan ReadMonth { get => readMonth; }
        public TimeSpan ReadYear { get => readYear; }
        public TimeSpan ReadAllTime { get => readAllTime; }
        public List<Statistics> DailyStatistics { get => dailyStatistics; set => dailyStatistics = value; }
        public Statistics Statistics { get => statistics; set => statistics = value; }
        #endregion


        public StatisticsViewModel()
        {
            BookDB.GetStatBooksLibrary(ref countBooks, ref txtCountBooks, ref pdfCountBooks);
            BookHistoryDB.GetStatTotalBooksLibrary(ref countTotalBooks, ref txtTotalCountBooks, ref pdfTotalCountBooks);

            dailyStatistics = StatisticsDB.GetReadStatisticsToday();
            readToday = new TimeSpan(dailyStatistics.Sum(t => t.ReadTime.Ticks));
            StatisticsDB.GetReadTime(ref readWeek, ref readMonth, ref readYear, ref readAllTime);
        }
        #endregion
    }
}
