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

        public Note AddNote(string title, string content)
        {
            Note newNote = new Note(title, content);
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
                    Note note = new Note()
                    {
                        Title = parts[0],
                        Content = parts[1]
                    };
                    Notes.Add(note);
                }
            }
        }

        public void SaveNotes()
        {
            List<string> lines = new List<string>();
            foreach (Note note in Notes)
            {
                string line = note.Title + "|" + note.Content;
                lines.Add(line);
            }
            File.WriteAllLines(notesFilePath, lines);
        }
        
        public void ModifyNote(Note note, string newTitle,string newContent)
        {
            note.Title = newTitle;
            note.Content = newContent;
            SaveNotes();
        }

        
    }
}