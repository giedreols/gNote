using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace gNote.DataStorage
{
    public static class Constants
    {
        public static ISharedPreferences LocalNotes = Application.Context.GetSharedPreferences("MyNotes", FileCreationMode.Private);
        public static string DbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbNote5.db3");
        public static SQLiteConnection Db;
    }
}