using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using gNote.DataStorage;
using SQLite;
using System;

namespace gNote
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SetDb();

            var buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            var buttonList = FindViewById<Button>(Resource.Id.buttonList);
            var noteText = FindViewById<EditText>(Resource.Id.textInputNote);

            var creationDate = DateTime.Now;



            buttonSave.Click += SaveAction;

            buttonList.Click += delegate
            {
                StartActivity(new Intent(this, typeof(NotesListActivity)));
            };
        }

        private void SaveAction(object sender, EventArgs e)
        {
            var note = new Note(Guid.NewGuid(), noteText.Text, creationDate, DateTime.Now);
            Constants.Db.Insert(note);

            Toast.MakeText(this, "Note saved", ToastLength.Short).Show();
        }

        private static void SetDb()
        {
            Constants.Db = new SQLiteConnection(Constants.DbPath);
            Constants.Db.CreateTable<Note>();
        }
    }
}