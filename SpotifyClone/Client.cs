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
<<<<<<< Updated upstream
                case ClientState.MainUserSelect:
                    MainUserSelect();
                    break;
                case ClientState.GeneralSelect:
                    GeneralSelect();
                    break;
                case ClientState.FriendSelect:
                    FriendSelect();
                    break;
=======
                Console.WriteLine(song.Name);
>>>>>>> Stashed changes
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
        
        char input = Input(
            new CommandEntry('g', "Dit is een goede optie!"),
            new CommandEntry('s', "Dit is een slechte optie,")
        );

        switch (input)
        {
            case 'g':
                Console.WriteLine("Goed resultaat");
                break;
            case 's':
                Console.WriteLine("Slecht resultaat");
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

    private char Input(params CommandEntry[] entries)
    {
        foreach (CommandEntry entry in entries)
            Console.WriteLine("[" + char.ToString(entry.Key) + "] - " + entry.Description);

        char input;
        do
        {
            Console.WriteLine("Kies een geldige optie...");
            input = Console.ReadKey().KeyChar;
            ClearLine();
        } while (!entries.Select(e => e.Key).Contains(input));

        return input;
    }

    private int Input(List<object> items)
    {
        for (int i = 0; i < items.Count; i++)
            Console.WriteLine("[" + i + "] - " + items[i]);

        int input;
        do
        {
            Console.WriteLine("Kies een geldige optie...");
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
            ClearLine();
        } while (input < 0 || input >= items.Count);
        
        return input;
    }
    
    private static void ClearLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }


    #endregion
}