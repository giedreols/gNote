using SQLite;
using System;

namespace gNote.DataStorage
{
    public class Note
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditingDate { get; set; }


        public Note(Guid id, string text, DateTime creationDate, DateTime editingDate)
        {
            Id = id;
            CreationDate = creationDate;
            EditingDate = editingDate;
            Text = text;
        }

        public Note()
        {
        }

        public override string ToString()
        {
            return Text + "\nCreated: " + CreationDate.ToString() + "\nEdited: " + EditingDate.ToString();
        }


    }

}