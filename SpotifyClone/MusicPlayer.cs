using System.Collections.Immutable;
using NAudio.Wave;
using SpotifyClone.Entities;

namespace SpotifyClone;

public class MusicPlayer
{
    public Song? CurrentSong { get; private set; }
    public ImmutableList<Song> SongQueue => _songQueue.ToImmutableList();
    
    private WaveOutEvent _player = new();
    private AudioFileReader? _audioReader;
    private readonly Queue<Song> _songQueue = [];

    public void PlaySong(Song song)
    {
        throw new NotImplementedException();
    }

    public void AppendQueue(IEnumerable<Song> songs)
    {
        throw new NotImplementedException();
    }

    public void ClearQueue()
    {
        throw new NotImplementedException();
    }

    public void StopPlaying()
    {
        throw new NotImplementedException();
    }

    public void SkipSong()
    {
        throw new NotImplementedException();
    }

    public void TogglePause()
    {
        throw new NotImplementedException();
    }
}