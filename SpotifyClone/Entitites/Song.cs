namespace SpotifyClone.Entities
{
    public class Song
    {
        public string Name { get; private set; }
        public Artist Artist { get; private set; }
        public double Duration { get; private set; }
        public string Genre { get; private set; }
        public string ReleaseDate { get; private set; }

        public Song(string name, Artist artist, double duration, string genre, string releaseDate)
        {
            Name = name;
            Artist = artist;
            Duration = duration;
            Genre = genre;
            ReleaseDate = releaseDate;
        }
        
        
    }
}