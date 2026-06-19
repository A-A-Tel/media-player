using SpotifyClone.Entities;

namespace SpotifyClone;

public class Client
{
    private readonly MusicPlayer _musicPlayer = new();
    private User _mainUser = User.GetAllUsers()[0]; // This is temporary
    private ClientState _state = ClientState.MainUserSelect; // This should be MainUserSelect when that feature is ready

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

    private void PlaySong()
    {
        Song song = SongSelectMenu();
        _musicPlayer.PlaySong(song);
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
        Console.WriteLine("Kies de hoofdgebruiker!");

        _mainUser = UserSelectMenu();

        _state = ClientState.GeneralSelect;
    }

    private void GeneralSelect()
    {
        Console.WriteLine("Welkom " + _mainUser);

        if (_musicPlayer.CurrentSong != null)
        {
            Console.WriteLine("We spelen nu:" + _musicPlayer.CurrentSong.Name);
        }
        
        char input = Input(
            new CommandEntry('s', "Speel nummer af"),
            new CommandEntry('a', "Laat alle artiesten zien"),
            new CommandEntry('b', "Laat alle albums zien"),
            new CommandEntry('g', "Uitloggen")

        );

        switch (input)
        {

            case 's':
                PlaySong();
                break;
            case 'a':
                ArtistSelectMenu();
                break;
            case 'g':
                Console.WriteLine("Uitgelogd!");
                _state = ClientState.MainUserSelect;
                break;
            case 'b':
                AlbumSelectMenu();
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
        Console.WriteLine("Nummers:");
        return Input(Song.GetAllSongs());
    }
    
    private Artist ArtistSelectMenu()
    {
        Console.WriteLine("Artiesten:");
        return Input(Artist.GetAllArtists());
    }


    private User UserSelectMenu()
    {
        Console.WriteLine("Gebruikers:");
        return Input(User.GetAllUsers());
    }

    private Album AlbumSelectMenu()
    {
        Console.WriteLine("Albums:");
        return Input(Album.GetAllAlbums());
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

    private T Input<T>(List<T> items)
        where T : class
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
        
        return items[input];
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