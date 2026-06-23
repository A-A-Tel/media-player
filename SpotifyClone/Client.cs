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
    
    private void AddFriend()
    {
        List<User> friends = _mainUser.Friends;
        List<User> users = User.GetAllUsers();
        Console.WriteLine("Kies een gebruiker om een vriendschapsverzoek te sturen");

        int index = Input(users);
        User gekozen = users[index];
        if (gekozen == _mainUser)
        {
            Console.WriteLine("Je kan jezelf niet als vriend toevoegen!");
            return;
        }
        friends.Add(gekozen);
        Console.WriteLine("verzoek gestuurd naar " + gekozen);
    }
    
    private void ViewFriends()
    {   
        List<User> friends = _mainUser.Friends;
        Console.WriteLine("Vrienden:");

        if (friends.Count == 0)
        {
            Console.WriteLine("Nog geen vrienden!");
            return;
        }

        foreach (User friend in friends)
        {
            if (friend.Friends.Contains(_mainUser))
                Console.WriteLine(friend.Name);
            else
                Console.WriteLine(friend.Name + " (verzoek nog niet beantwoord!)");
        }
    }
    
    private void RemoveFriend()
    {
        List<User> friends = _mainUser.Friends;
        if (friends.Count == 0)
        {
            Console.WriteLine("geen vrienden om te verwijderen!");
            return;
        }
        Console.WriteLine("Kies een vriend om te verwijderen");
        int index = Input(friends);
        User gekozen = friends[index];
        friends.Remove(gekozen);
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
            new CommandEntry('v', "Laat alle vrienden zien"),
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
            case 'v':
                FriendSelect();
                break;
            case 'u':
                Console.WriteLine("Uitgelogd!");
                _state = ClientState.MainUserSelect;
                break;
            case 'l':
                AlbumSelectMenu();
                break;
            case 'j':
                ViewArtistAlbums();
                break;

        }
    }

    private void FriendSelect()
    {
        Console.WriteLine("[0] - terug");
        Console.WriteLine("[1] - vrienden inzien");
        Console.WriteLine("[2] - vriend verzoek sturen");
        Console.WriteLine("[3] - vriend verwijderen");

        string? antwoord = Console.ReadLine();

        switch (antwoord)
        {
            case "0":
                _state = ClientState.GeneralSelect;
                break;
            case "1":
                ViewFriends();
                break;
            case "2":
                AddFriend();
                break;
            case "3":
                RemoveFriend();
                break;
        }
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