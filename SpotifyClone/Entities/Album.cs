namespace SpotifyClone.Entities;

public class Album
{
    private readonly static List<Album> _albums =
      [
        new("A Night at the Opera"),
        new("Led Zeppelin IV"),
        new("Hotel California")
      ];

    public string Name { get; private set; }
    public List<Artist> Artists { get; private set; } = [];
    public List<Song> Songs { get; private set; } = [];

    public Album(string name)
    {
        Name = name;
    }

    public static List<Album> GetAllAlbums()
    {
        return _albums;
    }

    public override string ToString()
    {
        return Name;
    }
}