using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using gNote.DataStorage;
using gNote.Utilities;
using SQLite;

namespace gNote
{
    [Activity(Label = "NoteEditingActivity")]
    public class NoteEditingActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            var buttonList = FindViewById<Button>(Resource.Id.buttonList);
            var noteText = FindViewById<EditText>(Resource.Id.textInputNote);

            var intent = new Intent(this, typeof(NotesListActivity));

            var table = Constants.Db.Table<Note>();
            
            foreach (var item in table)
            {
                if (item.Id.Equals(NotesListActivity.Id))
                {
                    noteText.Text = item.Text;
                    break;
                }
            }

            buttonSave.Click += delegate
            {
                var note = new Note(NotesListActivity.Id, noteText.Text, NotesListActivity.CreationDate, DateTime.Now);

                Constants.Db.Update(note);

                Android.Widget.Toast.MakeText(this, "Note saved", ToastLength.Short).Show();
            };

            buttonList.Click += delegate
            {
                StartActivity(intent);
            };
        }



    }
}