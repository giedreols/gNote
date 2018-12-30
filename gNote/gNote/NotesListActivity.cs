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
        //string[] items;
        IList<Note> items;

        public static Guid Id;
        public static DateTime CreationDate;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            //// display created data
            //var noteTextContent = FindViewById<TextView>(Resource.Id.noteTextContent);
            //var noteCreationDateContent = FindViewById<TextView>(Resource.Id.noteCreationDateContent);
            //var noteEditingDateContent = FindViewById<TextView>(Resource.Id.noteEditingDateContent);

            //// display list
            //noteTextContent.Text = Note.Text;
            //noteCreationDateContent.Text = Note.CreationDate.ToString();
            //noteEditingDateContent.Text = Note.EditingDate.ToString();

            //// retrieve data from shared preferences        
            //items = new string[] { "cats", "cucumbers", "dragons" };
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);

            //var localNotes = MainActivity.LocalNotes;

            //var noteText = localNotes.GetString("Text", null);
            //var noteCreated = localNotes.GetString("Created", null);
            //var noteEdited = localNotes.GetString("Edited", null);

            //var note = new Note(noteText, noteCreated, noteEdited);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.noteList);

            var table = Constants.Db.Table<Note>();

            items = new List<Note>();

            foreach (var item in table)
            {
                Note myNote = new Note(item.Id, item.Text, item.CreationDate, item.EditingDate);
                items.Add(myNote);
            }

            ListAdapter = new ArrayAdapter<Note>(this, Android.Resource.Layout.SimpleListItem1, items.ToArray());
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var selectedItem = items[position];

            Id = selectedItem.Id;
            CreationDate = selectedItem.CreationDate;

            // openn NoteEditingAtivity
            var intent = new Intent(this, typeof(NoteEditingActivity));
            StartActivity(intent);

            //    //shows toast popup of the item text
            //Android.Widget.Toast.MakeText(this, selectedItem, ToastLength.Short).Show();
            //var uri = Android.Net.Uri.Parse("https://www.google.lt/search?q=" + selectedItem);

            // var intent = new Intent(Intent.ActionView, uri);
            //  StartActivity(intent);
        }
    }
}