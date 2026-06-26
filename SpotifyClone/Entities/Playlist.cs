namespace SpotifyClone.Entities;

public class Playlist
{
    public string Name { get; private set; }
    public List<Song> Songs { get; private set; } = [];

    public void Add(Song song)
    {
        Songs.Add(song);
    }

    public void Remove(Song song)
    {
        Songs.Remove(song);
    }

    public void Rename(string newName)
    {
        Name = newName;
    }
}