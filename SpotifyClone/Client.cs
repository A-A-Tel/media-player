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
        _musicPlayer.StopPlaying();
    }

    private void ViewArtistAlbums()
    {
        Artist artist = ArtistSelectMenu();

        Console.WriteLine($"Albums van {artist.Name}:");


        List<Album> albums= Album.GetAllAlbums();
        foreach (Album album in albums)
        {
            if (album.Artists.Contains(artist))  
            {
                Console.WriteLine(album.Name);
            }
        }


    }


    private void ViewAlbumSongs()
    {
        Album selectedAlbum = AlbumSelectMenu();
        Console.WriteLine("Albums:" + selectedAlbum.Name);
         
        
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
            new CommandEntry('a', "Speel nummer af"),
            new CommandEntry('s', "Stop met afspelen"),
            new CommandEntry('c', "Laat alle artiesten zien"),
            new CommandEntry('l', "Laat alle albums zien"),
            new CommandEntry('u', "Uitloggen"),
            new CommandEntry('j', "Laat albums van geselecteerd artiest zien")
        );
        switch (input)
        {
            case 'a':
                PlaySong();
                break;
            case 's':
                StopPlayer();
                break;
            case 'c':
                ArtistSelectMenu();
                break;
            case 'l':
                Console.WriteLine("Uitgelogd!");
                _state = ClientState.MainUserSelect;
                break;
            case 'u':
                AlbumSelectMenu();
                break;
            case 'j':
                ViewArtistAlbums();
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