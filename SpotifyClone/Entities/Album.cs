namespace SpotifyClone.Entities;

public class Album
{
    private static readonly List<Album> Albums =
    [
        new("Nostalgia 2016", [Artist.GetAllArtists()[0]]),
        new("The most epic battles of rap", [Artist.GetAllArtists()[1]]),
        new("Derp", [Artist.GetAllArtists()[2], Artist.GetAllArtists()[3], Artist.GetAllArtists()[4]])
    ];

    public string Name { get; private set; }
    
    public List<Artist> Artists { get; private set; }
    public List<Song> Songs => Song.GetAllSongs().Where(s => s.Album == this).ToList();

    public Album(string name, List<Artist> artists)
    {
        Name = name;
        Artists = artists;
    }

    public static List<Album> GetAllAlbums()
    {
        return Albums;
    }

    public override string ToString()
    {
        return Name + " - " + string.Join(", ", Artists);
    }
}