using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesSomethingAAAA
{
    public class NotesManager
    {
        private readonly string notesFilePath;
        public List<Note> Notes { get; private set; }

        public NotesManager()
        {
            notesFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "notes.txt");

            Notes = new List<Note>();
        }
        

        public Note AddNote(string title, string content, DateTime DueDate, bool isDone)
        {
            Note newNote = new Note(title, content, DueDate, isDone);
            Notes.Add(newNote);
            SaveNotes();
            return newNote;
        }

        public void LoadNotes()
        {
            if (File.Exists(notesFilePath))
            {
                List<string> lines = File.ReadAllLines(notesFilePath).ToList();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    var Title = parts[0];
                    var Content = parts[1];
                    DateTime DueDate = Convert.ToDateTime(parts[2]);
                    bool isDone = Convert.ToBoolean(parts[3]);
                    Note note = new Note(Title, Content, DueDate, isDone);
                    Notes.Add(note);
                }
            }
        }
         
        public void SaveNotes()
        {
            List<string> lines = new List<string>();
            foreach (Note note in Notes)
            {
                string line = $"{note.Title}|{note.Content}|{note.DueDate}|{note.isDone}";

                lines.Add(line);
            }
            File.WriteAllLines(notesFilePath, lines);
        }
        
        public void DeleteNote(Note note)
        {
            Notes.Remove(note);
            SaveNotes();
        }

        public void ModifyNote(Note note, string newTitle, string newContent,DateTime date, bool done)
        {
            note.Title = newTitle;
            note.Content = newContent;
            note.DueDate = date;
            note.isDone = done;
            SaveNotes();
        }

        
    }
}