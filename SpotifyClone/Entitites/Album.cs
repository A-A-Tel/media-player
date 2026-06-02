namespace SpotifyClone.Entities
{
    public class Album
    {
        public string Title { get; private set; }

        public Album(string title)
        {
            Title = title;
        }
    }
}