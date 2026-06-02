namespace SpotifyClone.Entities
{
    public class Song
    {
        public string Title { get; private set; };
        public Artist artist { get; private set; };
        public double duration { get; private set; };
        pubic string genre { get; private set; };
        public string releaseDate { get; private set; };

        public Song(string title, Artist artist, double duration, string genre, string releaseDate)
        {
            Title = title;
            this.artist = artist;
            this.duration = duration;
            this.genre = genre;
            this.releaseDate = releaseDate;
        }

        public Song(string title)
        {
            Title = title;
        }
    }
}