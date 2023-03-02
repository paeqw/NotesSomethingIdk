using System.Windows;

namespace NotesSomethingAAAA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotesManager notesManager;

        public MainWindow()
        {
            InitializeComponent();
            notesManager = new NotesManager();
            notesManager.LoadNotes();
            NotesListBox.ItemsSource = notesManager.Notes;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Note newNote = notesManager.AddNote(TitleTextBox.Text, NoteTextBox.Text);
            NotesListBox.ItemsSource = null;
            NotesListBox.ItemsSource = notesManager.Notes;
            TitleTextBox.Text = "";
            NoteTextBox.Text = "";
        }

        private void NotesListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Note selectedNote = (Note)NotesListBox.SelectedItem;
            if (selectedNote != null)
            {
                TitleTextBox.Text = selectedNote.Title;
                NoteTextBox.Text = selectedNote.Content;
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            Note? selected = NotesListBox.SelectedItem as Note;
            if(selected == null)
            {
                MessageBox.Show("Select note to modify it");                return;
            }
            string newTitle = TitleTextBox.Text; 
            string newContent = NoteTextBox.Text;
            notesManager.ModifyNote(selected, newTitle, newContent);

            NotesListBox.Items.Refresh();
        }
    }
}
