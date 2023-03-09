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
            daysLeft.Text = Convert.ToString(Math.Round((note.DueDate - data).TotalDays, 2));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            bool ischecked = IsDoneCheck.IsChecked == true ? true : false;
            if (note == null)
            {
                daysLeft.Visibility = Visibility.Collapsed;
                daysLeftLabel.Visibility = Visibility.Collapsed;
                notesManager.AddNote(titleTextBox.Text, contentTextBox.Text, Convert.ToDateTime(DateText.Text), ischecked);
                this.Close();
            }
            else
            {
                daysLeft.Visibility = Visibility.Visible;
                daysLeftLabel.Visibility = Visibility.Visible;
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

