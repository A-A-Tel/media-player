namespace SpotifyClone.Entities
{
    public class Artist
    {
        public string Name { get; private set; }

       
           
        public List <Album> Albums { get; private set; } = new List<Album>();
        public List <Song> Songs { get; private set; } = new List<Song>();

        public Artist(string name)
        {
            Name = name;
        }
    }
}