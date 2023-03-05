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
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {// siema  chuju wymysl jak to odswiezyc
            
            if (note == null)
            {
                notesManager.AddNote(titleTextBox.Text, contentTextBox.Text);
                this.Close();
            }
            else
            {
                notesManager.ModifyNote(note, titleTextBox.Text, contentTextBox.Text);
                this.Close();
            }
        }
    }
}

