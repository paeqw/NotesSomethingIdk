using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            stackPanel.Visibility = Visibility.Hidden;
            stackPanel.Height = 0;
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            SolidColorBrush myBrush1 = new SolidColorBrush(Colors.Red);
            foreach (Note note in notesManager.Notes)
            {
                ListViewItem item = new ListViewItem();
                item.Content = note.Title;
                item.Tag = note;
                NotesListBox.Items.Add(item);
            }

            
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditNoteWindow addNoteWindow = new AddEditNoteWindow(notesManager);
            addNoteWindow.ShowDialog();
            refresh();
        }

        private void NotesListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            stackPanel.Visibility = Visibility.Visible;
            stackPanel.Height = double.NaN;
            Note? selectedNote = NotesListBox.SelectedItem as Note;


            if (NotesListBox.SelectedItem != null)
            {
                ListViewItem selectedNoteaaa = (ListViewItem?)NotesListBox.SelectedItem;
                Note tag = (Note)selectedNoteaaa.Tag;
                TitleTextBox.Text = tag.Title;
                NoteTextBox.Text = tag.Content;
            }
            else
            {
                stackPanel.Visibility = Visibility.Hidden;
                stackPanel.Height = 0;
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                MessageBox.Show("wybierz notatke");
                return;
            }
            ListViewItem selectedNoteaaa = (ListViewItem?)NotesListBox.SelectedItem;
            Note tag = (Note)selectedNoteaaa.Tag;
            AddEditNoteWindow editNoteWindow = new AddEditNoteWindow(notesManager);
            editNoteWindow.SetNote(tag);
            editNoteWindow.ShowDialog();
            refresh();
        }

        public void refresh()
        {
            NotesListBox.Items.Clear();

            foreach (Note note in notesManager.Notes)
            {
                ListViewItem item = new ListViewItem();
                item.Content = note.Title;
                item.Tag = note;
                NotesListBox.Items.Add(item);
            }
            foreach (ListViewItem item in NotesListBox.Items)
            {
                Note note = (Note)item.Tag;
                if (note.isDone)
                {
                    item.Background = Brushes.Green;
                }
                else
                {
                    item.Background = Brushes.White;
                }
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem == null)
            {
                MessageBox.Show("wybierz notatke");
                return;
            }
            ListViewItem selectedNoteaaa = (ListViewItem?)NotesListBox.SelectedItem;
            Note tag = (Note)selectedNoteaaa.Tag;
            notesManager.DeleteNote(tag);
            refresh();
        }
    }
}
