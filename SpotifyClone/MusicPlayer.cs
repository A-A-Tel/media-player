using System.Collections.Immutable;
using ManagedBass;
using SpotifyClone.Entities;

namespace SpotifyClone;

public class MusicPlayer
{
    public Song? CurrentSong { get; private set; }
    public ImmutableList<Song> SongQueue => _songQueue.ToImmutableList();
 
    private int _stream;
    private readonly Queue<Song> _songQueue = [];

    public MusicPlayer()
    {
        bool ok = Bass.Init();
        if (ok) return;
        
        Errors error = Bass.LastError;
        throw new Exception($"BASS error: {error}");
    }
    
    public void PlaySong(Song song)
    {
        if (_stream != 0)
        {
            Bass.ChannelStop(_stream);
            Bass.StreamFree(_stream);
            _stream = 0;
        }

        string songPath = Path.Combine("Songs/", song.FileName);
        _stream = Bass.CreateStream(songPath);

        if (_stream != 0)
        {
            Bass.ChannelPlay(_stream);
        }
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
        if (_stream != 0)
        {
            Bass.ChannelStop(_stream);
            Bass.StreamFree(_stream);
            _stream = 0;
        }
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