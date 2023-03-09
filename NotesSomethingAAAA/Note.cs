using System;

namespace NotesSomethingAAAA
{
    public class Note
    {
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool isDone { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
            // Set default title to empty string
            Title = "";
        }

        public Note(string title, string content, DateTime duedate, bool done)
        {
            Title = title;
            Content = content;
            CreationDate = DateTime.Now;
            DueDate = duedate;
            isDone = done;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
