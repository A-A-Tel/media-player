namespace SpotifyClone.Entities
{
    public class Song
    {
        public string Title { get; private set; }
        public Artist artist { get; private set; }
        public double Duration { get; private set; }
        public string Genre { get; private set; }
        public string ReleaseDate { get; private set; }

        public Song(string title, Artist artist, double duration, string genre, string releaseDate)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
            ReleaseDate = releaseDate;
        }

        public Song(string title)
        {
            Title = title;
        }
    }
}