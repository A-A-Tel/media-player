namespace SpotifyClone.Entities;

public class Playlist
{
    public string Name { get; private set; }
    public List<Song> Songs { get; private set; } = [];

    public void Add(Song song)
    {
        throw new NotImplementedException();
    }

    public void Remove(Song song)
    {
        throw new NotImplementedException();
    }

    public void Rename(string newName)
    {
        throw new NotImplementedException();
    }
}