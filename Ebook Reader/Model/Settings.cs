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
    public class Settings : SettingsDB
    {
        private string login;
        private string theme;
        private string language;
        private string fontStyle;


        [Key]
        [ForeignKey("User")]
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Theme
        {
            get => theme;
            set => theme = value;
        }
        public string Language
        {
            get => language;
            set => language = value;
        }
        public string FontStyle
        {
            get => fontStyle;
            set => fontStyle = value;
        }
        public User User { get; set; }


        public Settings(string login, string theme, string language, string fontStyle)
        {
            Login = login;
            Theme = theme;
            Language = language;
            FontStyle = fontStyle;
        }
        public Settings() { }


        public static void ChangeThemeDB(string newTheme) => SettingsDB.ChangeTheme(newTheme);
        public static void ChangeFontStyleDB(string newFontStyle) => SettingsDB.ChangeFontStyle(newFontStyle);
    }
}
