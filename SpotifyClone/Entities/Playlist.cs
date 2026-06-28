using System.Collections.Immutable;

namespace SpotifyClone.Entities;

public class Playlist
{
    private List<Song> _songs = [];

    public Playlist(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public ImmutableList<Song> Songs => _songs.ToImmutableList();

    public void Add(Song song)
    {
        _songs.Add(song);
    }

    public void Remove(Song song)
    {
        _songs.Remove(song);
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    public override string ToString()
    {
        return Name;
    }
}