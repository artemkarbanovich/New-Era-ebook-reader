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
    public class SettingsDB
    {
        public static Settings GetSettingsByLogin()
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    Settings settings = context.Settings.FirstOrDefault(s => s.Login.ToLower() == ActiveUser.User.Login.ToLower());
                    return settings;
                }
            }
            catch { return null; }
        }

        private protected static void ChangeTheme(string newTheme)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    Settings settings = context.Settings.FirstOrDefault(s => s.Login == ActiveUser.User.Login);
                    settings.Theme = newTheme;
                    context.SaveChanges();
                }
            }
            catch { }
        }

        private protected static void ChangeFontStyle(string newFontStyle)
        {
            try
            {
                using (UserContext context = new UserContext())
                {
                    Settings settings = context.Settings.FirstOrDefault(s => s.Login == ActiveUser.User.Login);
                    settings.FontStyle = newFontStyle;
                    context.SaveChanges();
                }
            }
            catch { }
        }
    }
}
