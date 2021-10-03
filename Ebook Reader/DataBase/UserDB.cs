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
    public class UserDB
    {
        private protected static async void CreateUser(User user)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (UserContext context = new UserContext())
                    {
                        context.Users.Add(user);
                        context.SaveChanges();

                        Settings settings = new Settings(user.Login.ToLower(), "Стандартная", "Русский", "Segoe UI");
                        context.Settings.Add(settings);
                        context.SaveChanges();
                    }
                });
            }
            catch { }
        }

        public static bool CheckLogin(string login)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    var log = context.Users.Where(l => l.Login.ToLower() == login.ToLower());

                    if (log.Count() == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch { return false; }
        }

        public static User ReturnUserByLogin(string login)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    var user = context.Users.Where(u => u.Login == login);
                    return user.First();
                }
            }
            catch { return null; }
        }

        private protected static void DeleteAccount()
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (Book b in context.Books.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()))
                                context.Books.Remove(b);
                            context.SaveChanges();

                            foreach (BookHistory b in context.BooksHistory.Where(b => b.Login.ToLower() == ActiveUser.User.Login.ToLower()))
                                context.BooksHistory.Remove(b);
                            context.SaveChanges();

                            foreach (Statistics s in context.Statistics.Where(s => s.Login.ToLower() == ActiveUser.User.Login.ToLower()))
                                context.Statistics.Remove(s);
                            context.SaveChanges();

                            Settings settings = context.Settings.FirstOrDefault(s => s.Login == ActiveUser.User.Login);
                            context.Settings.Remove(settings);
                            context.SaveChanges();

                            User user = context.Users.FirstOrDefault(u => u.Login.ToLower() == ActiveUser.User.Login.ToLower());
                            context.Users.Remove(user);
                            context.SaveChanges();

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка удаления.\n" +
                                $"Сообщение: {e.Message}.");
                        }
                    }
                }
            }
            catch { }
        }
    }
}
