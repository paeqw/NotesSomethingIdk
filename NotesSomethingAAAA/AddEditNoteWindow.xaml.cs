using System;
using System.Windows;

namespace NotesSomethingAAAA
{
    public partial class AddEditNoteWindow : Window
    {
        private NotesManager notesManager;
        private Note note;
        // nie wiem bugi ale dziala wiec nie ma buguf
        public AddEditNoteWindow(NotesManager notesManager)
        {
            InitializeComponent();
            this.notesManager = notesManager;
        }

        public void SetNote(Note note)
        {
            this.note = note;
            titleTextBox.Text = note.Title;
            contentTextBox.Text = note.Content;
            IsDoneCheck.IsChecked = note.isDone;
            DateText.Text = note.DueDate.ToString();
            DateTime data = DateTime.Now;
            daysLeft.Text = Convert.ToString(note.DueDate - data);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            bool ischecked = IsDoneCheck.IsChecked == true ? true : false;
            if (note == null)
            {
                notesManager.AddNote(titleTextBox.Text, contentTextBox.Text, Convert.ToDateTime(DateText.Text), ischecked);
                this.Close();
            }
            else
            {
                notesManager.ModifyNote(note, titleTextBox.Text, contentTextBox.Text, Convert.ToDateTime(DateText.Text), ischecked);
                this.Close();
            }
            a.refresh();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}

