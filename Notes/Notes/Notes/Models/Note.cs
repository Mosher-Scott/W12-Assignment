using System;
using SQLite;

namespace Notes.Models
{
    public class Note
    {
        // Set the primary key, and also make sure it it autoincrements
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}