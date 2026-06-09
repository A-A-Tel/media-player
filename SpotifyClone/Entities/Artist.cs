namespace SpotifyClone.Entities;

public class Artist
{
    private readonly static List<Artist> _artists =
       [
           new("Queen"),
           new("Led Zeppelin"),
            new("Eagles")
       ];
    public string Name { get; private set; }
    public List<Album> Albums { get; private set; } = [];
    public List<Song> Songs { get; private set; } = [];

    public Artist(string name)
    {
        Name = name;
    }

    public static List<Artist> GetAllArtists()
    {
       return _artists;
    }

    public override string ToString()
    {
        return Name;
    }
}