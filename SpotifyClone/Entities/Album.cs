namespace SpotifyClone.Entities;

public class Album
{
    private readonly static List<Album> _albums =
      [
        new("A Night at the Opera", Artist.GetAllArtists()[0]),
        new("Led Zeppelin IV", Artist.GetAllArtists()[1]),
        new("Hotel California", Artist.GetAllArtists()[2])
      ];

    public string Name { get; private set; }
    public List<Artist> Artists { get; private set; } = [];
    public List<Song> Songs { get; private set; } = [];
    public Artist Artist { get; private set; }

    public Album(string name , Artist artist)
    {
        Name = name;
        Artist = artist;
        artist.Albums.Add(this);
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