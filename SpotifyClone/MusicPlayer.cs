using System.Collections.Immutable;
using ManagedBass;
using SpotifyClone.Entities;

namespace SpotifyClone;

public class MusicPlayer
{
    public Song? CurrentSong { get; private set; }
    public ImmutableList<Song> SongQueue => _songQueue.ToImmutableList();
 
    private int _stream;
    private SyncProcedure? _endSyncProcedure;
    public bool Shuffle { get; private set; }
    
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
        StopPlaying();

        string songPath = Path.Combine("Songs/", song.FileName);
        _stream = Bass.CreateStream(songPath, Flags: BassFlags.AutoFree);

        if (_stream != 0)
        {
            Bass.ChannelPlay(_stream);
            _endSyncProcedure = OnSongEnd;
            Bass.ChannelSetSync(_stream, SyncFlags.End, 0, _endSyncProcedure);
        }

        CurrentSong = song;
    }

    public void AppendQueue(params IEnumerable<Song> songs)
    {
        foreach (Song song in songs)
        {
            _songQueue.Enqueue(song);
        }
        if (_stream == 0) SkipSong();
    }

    public void ClearQueue()
    {
        _songQueue.Clear();
        StopPlaying();
    }

    public void StopPlaying()
    {
        if (_stream != 0)
        {
            Bass.ChannelStop(_stream);
            _stream = 0;
        }
    }

    public void SkipSong()
    {
        if (_songQueue.Count > 0)
        {
            if (Shuffle)
            {
                Random random = new();
                PlaySong(_songQueue.DequeueRandom());
            }
            else
            {
                PlaySong(_songQueue.Dequeue());
            }
        }
        else
        {
            StopPlaying();
        }
    }

    public void TogglePause()
    {
        throw new NotImplementedException();
    }

    public void ToggleShuffle()
    {
        Shuffle = !Shuffle;
    }

    private void OnSongEnd(int handle, int channel, int data, IntPtr user)
    {
        SkipSong();
    }
}