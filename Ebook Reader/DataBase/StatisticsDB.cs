using Ebook_Reader.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ebook_Reader.DataBase
{
    public class StatisticsDB
    {
        private protected static void SaveStatistics(Statistics stat)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    context.Statistics.Add(stat);
                    context.SaveChanges();
                }
            }
            catch { }
        }

        public static List<Statistics> GetReadStatisticsToday()
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    DateTime dateTime = DateTime.Now;

                    var group = context.Statistics
                                .Where(s => s.Login.ToLower() == ActiveUser.User.Login.ToLower())
                                .Where(s => DbFunctions.TruncateTime(s.CurrentDate) == dateTime.Date)
                                .GroupBy(c => new { c.BookName, c.BookFormat })
                                .ToList()
                                .Select(gcp => new Statistics
                                {
                                    BookName = gcp.Key.BookName,
                                    BookFormat = gcp.Key.BookFormat,
                                    ReadTime = gcp.Aggregate(TimeSpan.Zero, (sumSoFar, nextMyObject) => sumSoFar + nextMyObject.ReadTime)
                                });

                    return group.OrderByDescending(s => s.ReadTime).ToList();
                }
            }
            catch { return null; }
        }

        public static void GetReadTime(ref TimeSpan tWeek, ref TimeSpan tMonth, ref TimeSpan tYear, ref TimeSpan tAll)
        {

            tWeek = GetReadTimeLinq('w');
            tMonth = GetReadTimeLinq('m');
            tYear = GetReadTimeLinq('y');
            tAll = GetReadTimeLinq('a');
        }
        
        private static TimeSpan GetReadTimeLinq(char date)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    DateTime dateTime = new DateTime();

                    if (date == 'w')
                        dateTime = DateTime.Now.AddDays(-7);
                    else if (date == 'm')
                        dateTime = DateTime.Now.AddMonths(-1);
                    else if (date == 'y')
                        dateTime = DateTime.Now.AddYears(-1);
                    else if (date == 'a')
                    {
                        var timeAll = context.Statistics
                                     .Where(s => s.Login.ToLower() == ActiveUser.User.Login.ToLower())
                                     .GroupBy(c => new { c.BookName, c.BookFormat })
                                     .ToList()
                                     .Select(gcp => new Statistics
                                     {
                                         BookName = gcp.Key.BookName,
                                         BookFormat = gcp.Key.BookFormat,
                                         ReadTime = gcp.Aggregate(TimeSpan.Zero, (sumSoFar, nextMyObject) => sumSoFar + nextMyObject.ReadTime)
                                     }).ToList();

                        return new TimeSpan(timeAll.Sum(t => t.ReadTime.Ticks));
                    }

                    var timeByParam = context.Statistics
                                      .Where(s => s.Login.ToLower() == ActiveUser.User.Login.ToLower())
                                      .Where(s => DbFunctions.TruncateTime(s.CurrentDate) > dateTime.Date)
                                      .GroupBy(c => new { c.BookName, c.BookFormat })
                                      .ToList()
                                      .Select(gcp => new Statistics
                                      {
                                          BookName = gcp.Key.BookName,
                                          BookFormat = gcp.Key.BookFormat,
                                          ReadTime = gcp.Aggregate(TimeSpan.Zero, (sumSoFar, nextMyObject) => sumSoFar + nextMyObject.ReadTime)
                                      }).ToList();

                    return new TimeSpan(timeByParam.Sum(t => t.ReadTime.Ticks));
                }
            }
            catch { return new TimeSpan(0, 0, 0); }
        }
    }
}
