namespace SpotifyClone.Entities
{
    public class Song
    {
        public string Title { get; private set; }

        public Song(string title)
        {
            Title = title;
        }
    }
}