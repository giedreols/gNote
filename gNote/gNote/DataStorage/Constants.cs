using Android.App;
using Android.Content;
using SQLite;
using System;
using System.IO;

namespace gNote.DataStorage
{
    public static class Constants
    {
        //public static ISharedPreferences LocalNotes = Application.Context.GetSharedPreferences("MyNotes", FileCreationMode.Private);
        public static string DbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbNote.db3");
        public static SQLiteConnection Db;

        public static Guid CurrentItemGuid;
        public static DateTime CurrentItemCreationDate;
    }
}