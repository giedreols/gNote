using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using gNote.DataStorage;
using System;
using SQLite;
using System.IO;
using gNote.Utilities;

namespace gNote
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetDb();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            var buttonList = FindViewById<Button>(Resource.Id.buttonList);
            var noteText = FindViewById<EditText>(Resource.Id.textInputNote);

            var NoteListIntent = new Intent(this, typeof(NotesListActivity));

            var creationDate = DateTime.Now;

            buttonSave.Click += delegate
            {
                // add the new item to the share preferences
                //var notesEdit = LocalNotes.Edit();
                //notesEdit.PutString("Text", noteText.Text);
                //notesEdit.PutString("Created", creationDate.ToString());
                //notesEdit.PutString("Edited", DateTime.Now.ToString());
                //notesEdit.Commit();

                var note = new Note(Guid.NewGuid(), noteText.Text, creationDate, DateTime.Now);

                // add the item to the db
                Constants.Db.Insert(note);

                Toast.MakeText(this, "Note saved", ToastLength.Short).Show();
            };

            buttonList.Click += delegate
            {
                StartActivity(NoteListIntent);
            };
        }

        private static void SetDb()
        {
            Constants.Db = new SQLiteConnection(Constants.DbPath);
            Constants.Db.CreateTable<Note>();
        }
    }
}