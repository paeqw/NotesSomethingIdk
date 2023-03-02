namespace NotesSomethingAAAA
{
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
            // Set default title to empty string
            Title = "";
        }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
