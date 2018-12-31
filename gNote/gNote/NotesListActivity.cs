using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using gNote.DataStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gNote
{
    [Activity(Label = "NotesListActivity")]
    public class NotesListActivity : ListActivity
    {
        //string[] _items;
        private IList<Note> _items;
        private TableQuery<Note> _table;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            //// display created data
            //var noteTextContent = FindViewById<TextView>(Resource.Id.noteTextContent);
            //var noteCreationDateContent = FindViewById<TextView>(Resource.Id.noteCreationDateContent);
            //var noteEditingDateContent = FindViewById<TextView>(Resource.Id.noteEditingDateContent);

            //// display list
            //noteTextContent.Text = Note.Text;
            //noteCreationDateContent.Text = Note.CurrentItemCreationDate.ToString();
            //noteEditingDateContent.Text = Note.EditingDate.ToString();

            //// retrieve data from shared preferences        
            //_items = new string[] { "cats", "cucumbers", "dragons" };
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _items);

            //var localNotes = MainActivity.LocalNotes;

            //var noteText = localNotes.GetString("Text", null);
            //var noteCreated = localNotes.GetString("Created", null);
            //var noteEdited = localNotes.GetString("Edited", null);

            //var note = new Note(noteText, noteCreated, noteEdited);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.noteList);

            _table = Constants.Db.Table<Note>();
            _items = new List<Note>();

            foreach (var item in _table)
            {
                var myNote = new Note(item.Id, item.Text, item.CreationDate, item.EditingDate);
                _items.Add(myNote);
            }

            ListAdapter = new ArrayAdapter<Note>(this, Android.Resource.Layout.SimpleListItem2, _items.ToArray());
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var selectedItem = _items[position];

            Constants.CurrentItemGuid = selectedItem.Id;
            Constants.CurrentItemCreationDate = selectedItem.CreationDate;

            StartActivity(new Intent(this, typeof(NoteEditingActivity)));

            //    //shows toast popup of the item text
            //Android.Widget.Toast.MakeText(this, selectedItem, ToastLength.Short).Show();
            //var uri = Android.Net.Uri.Parse("https://www.google.lt/search?q=" + selectedItem);

            // var intent = new Intent(Intent.ActionView, uri);
            //  StartActivity(intent);
        }
    }
}