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
        while (_state != ClientState.Stopped)
            switch (_state)
            {
                case ClientState.MainUserSelect:
                    MainUserSelect();
                    break;
                case ClientState.GeneralSelect:
                    GeneralSelect();
                    break;
                case ClientState.FriendSelect:
                    FriendSelect();
                    break;
            }
    }

    #region Actions
    
    private void AppendQueue(Song song)
    {
        throw new NotImplementedException();
    }

    private void PlaySong(Song song)
    {
        throw new NotImplementedException();
    }

    private void SkipSong()
    {
        throw new NotImplementedException();
    }

    private void TogglePause()
    {
        throw new NotImplementedException();
    }

    private void StopPlayer()
    {
        throw new NotImplementedException();
    }
    
    #endregion

    #region State

    private void MainUserSelect()
    {
        throw new NotImplementedException();
    }

    private void GeneralSelect()
    {
        FlushTerminal();
        
        Console.WriteLine($"Welkom {_mainUser.Name}!");
        Console.WriteLine("[a] Commando 1 - Goed");
        Console.WriteLine("[b] Commando 2 - Fout");
        char input = Input('a', 'b');

        switch (input)
        {
            case 'a':
                Console.WriteLine("(Correcte output)");
                break;
            case 'b':
                Console.WriteLine("(Foute output)");
                break;
        }
    }

    private void FriendSelect()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region ActionMenus

    private Song SongSelectMenu()
    {
        throw new NotImplementedException();
    }

    private User UserSelectMenu()
    {
        throw new NotImplementedException();
    }

    private Playlist PlaylistSelectMenu()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Helpers

    private void FlushTerminal()
    {
        Console.Clear();
    }

    private char Input(params char[] allowedChars)
    {
        char input = '⠀';

        do {
            Console.WriteLine(input == '⠀' ? "Kies 1 van de opties... " : "Fout, probeer het opnieuw... ");
            input = Console.ReadKey().KeyChar;
        } while (!allowedChars.Contains(char.ToLower(input)));

        return input;
    }

    #endregion
}