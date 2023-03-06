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
            stackPanel.Visibility = Visibility.Hidden;
            stackPanel.Height = 0;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditNoteWindow addNoteWindow = new AddEditNoteWindow(notesManager);
            addNoteWindow.ShowDialog();
            NotesListBox.Items.Refresh();
        }

        private void NotesListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            stackPanel.Visibility = Visibility.Visible;
            stackPanel.Height = double.NaN;
            Note? selectedNote = NotesListBox.SelectedItem as Note;
            if (selectedNote != null)
            {
                TitleTextBox.Text = selectedNote.Title;
                NoteTextBox.Text = selectedNote.Content;
            }
            else
            {
                stackPanel.Visibility = Visibility.Hidden;
                stackPanel.Height = 0;
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            // pytajnik -> moze byc null
            Note? selectedNote = NotesListBox.SelectedItem as Note;
            if (selectedNote == null)
            {
                MessageBox.Show("a a a a chujjjjjj a da a a aa a a a  a ive lost my mid a a a a a");
                return;
            }
            AddEditNoteWindow editNoteWindow = new AddEditNoteWindow(notesManager);
            editNoteWindow.SetNote(selectedNote);
            editNoteWindow.ShowDialog();
            NotesListBox.Items.Refresh();
        }

        public void refresh() {
            NotesListBox.Items.Refresh();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Note? selectedNote = NotesListBox.SelectedItem as Note;

            if (selectedNote == null)
            {
                MessageBox.Show("a a a a chujjjjjj a da a a aa a a a  a ive lost my mid a a a a a");
                return;
            }
            notesManager.DeleteNote(selectedNote);
            NotesListBox.Items.Refresh();
        }
    }
}
