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
        private Button _buttonSave;
        private Button _buttonList;
        private EditText _noteText;
        private TableQuery<Note> _table;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            _buttonList = FindViewById<Button>(Resource.Id.buttonList);
            _noteText = FindViewById<EditText>(Resource.Id.textInputNote);

            _table = Constants.Db.Table<Note>();

            _noteText.Text = GetCurrentNote().Text;

            _buttonSave.Click += OnButtonSaveOnClick;

            _buttonList.Click += delegate
            {
                if (_noteText.Text.Trim().Length == 0)
                {
                    Constants.Db.Delete(GetCurrentNote());
                }

                StartActivity(new Intent(this, typeof(NotesListActivity)));
            };
        }

        private Note GetCurrentNote()
        {
            foreach (var item in _table)
            {
                if (!item.Id.Equals(Constants.CurrentItemGuid)) continue;
                return item;
            }
            throw new NullReferenceException("Could not find current note");
        }

        void OnButtonSaveOnClick(object sender, EventArgs e)
        {
            var note = new Note(Constants.CurrentItemGuid, _noteText.Text, Constants.CurrentItemCreationDate, DateTime.Now);
            
            if (_noteText.Text.Trim().Length != 0)
            {
                Constants.Db.Update(note);
            }

            Android.Widget.Toast.MakeText(this, "Note saved", ToastLength.Short).Show();
        }
    }
}