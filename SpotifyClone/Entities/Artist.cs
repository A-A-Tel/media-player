namespace SpotifyClone.Entities;

public class Artist
{
    public string Name { get; private set; }
    public List<Album> Albums { get; private set; } = [];
    public List<Song> Songs { get; private set; } = [];

    public Artist(string name)
    {
        Name = name;
    }

    public static List<Artist> GetAllArtists()
    {
        throw new NotImplementedException();
    }
}