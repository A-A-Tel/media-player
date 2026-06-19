namespace SpotifyClone.Entities;

public class Artist
{
    private static readonly List<Artist> Artists =
    [
        new("NCS"),
        new("ERB"),
        new("Kevin Macleod"),
        new("Daniwell"),
        new("Daimaou Kosaka")
    ];
    public string Name { get; private set; }
    public List<Album> Albums => Album.GetAllAlbums().Where(a => a.Artists.Contains(this)).ToList();
    public List<Song> Songs => Song.GetAllSongs().Where(s => s.Artists.Contains(this)).ToList();

    public Artist(string name)
    {
        Name = name;
    }

    public static List<Artist> GetAllArtists()
    {
       return Artists;
    }

    public override string ToString()
    {
        return Name;
    }
}