using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NotesSomethingAAAA
{
	public class NotesManager
	{
		private readonly string notesFilePath;
		public List<Note> Notes { get; private set; }

		public NotesManager()
		{
			notesFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "notes.xml");

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
				var notesXml = XDocument.Load(notesFilePath);
				Notes = notesXml.Root
					.Elements("note")
					.Select(noteXml => new Note(
						noteXml.Element("title").Value,
						noteXml.Element("content").Value,
						DateTime.Parse(noteXml.Element("dueDate").Value),
						bool.Parse(noteXml.Element("isDone").Value)
					))
					.ToList();
			}
		}
		 
		public void SaveNotes()
		{//System.Xml.Linq.
			var notesXml = new XElement("notes",
				Notes.Select(note => new XElement("note",
					new XElement("title", note.Title),
					new XElement("content", note.Content),
					new XElement("dueDate", note.DueDate),
					new XElement("isDone", note.isDone)
				))
			);

			notesXml.Save(notesFilePath);
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
// tabulatory >> spacje dlatego wywalilo changes w kazdej linijce poggers