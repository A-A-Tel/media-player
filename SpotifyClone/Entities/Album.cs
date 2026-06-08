namespace SpotifyClone.Entities;

public class Album
{
    public string Name { get; private set; }
    public List<Artist> Artists { get; private set; } = [];
    public List<Song> Songs { get; private set; } = [];

    public Album(string name)
    {
        Name = name;
    }

    public static List<Album> GetAllAlbums()
    {
        throw new NotImplementedException();
    }
}