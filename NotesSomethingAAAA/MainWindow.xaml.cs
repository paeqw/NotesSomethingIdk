using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
