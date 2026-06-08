using SpotifyClone.Entities;
using System.Media;
using NAudio.Wave;

namespace SpotifyClone;

public class Client
{
    private User _mainUser = User.GetAllUsers()[0]; // This is temporary
    private Song? _currentSong;
    private WaveOutEvent _player = new();
    private AudioFileReader? _audioReader;
    private Queue<Song> _queue = new();
    private ClientState _state = ClientState.GeneralSelect; // This should be MainUserSelect when that feature is ready

    public void Start()
    {
    }

    #region Actions
    
    public void AppendQueue(Song song)
    {
        throw new NotImplementedException();
    }

    public void PlaySong(Song song)
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

    public void StopPlayer()
    {
        throw new NotImplementedException();
    }
    
    #endregion

    #region State

    public void MainUserSelect()
    {
        throw new NotImplementedException();
    }

    public void GeneralSelect()
    {
        Console.WriteLine($"Welcome {_mainUser.Name}");
    }

    public void FriendSelect()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region ActionMenus

    public Song SongSelectMenu()
    {
        throw new NotImplementedException();
    }

    public User UserSelectMenu()
    {
        throw new NotImplementedException();
    }

    public Playlist PlaylistSelectMenu()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Helpers

    public void FlushTerminal()
    {
        Console.Clear();
    }

    public char Input(params char[] allowedChars)
    {
        throw new NotImplementedException();
    }

    #endregion
}