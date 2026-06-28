using SpotifyClone.Entities;

namespace SpotifyClone;

public class Client
{
    private readonly MusicPlayer _musicPlayer = new();
    private User _mainUser = User.GetAllUsers()[0]; // This is temporary
    private ClientState _state = ClientState.MainUserSelectState; // This should be MainUserSelect when that feature is ready

    public void Start()
    {
        while (_state != ClientState.Stopped)
            switch (_state)
            {
                case ClientState.MainUserSelectState:
                    MainUserSelect();
                    break;
                case ClientState.GeneralState:
                    GeneralSelect();
                    break;
                case ClientState.FriendState:
                    FriendSelect();
                    break;
                case ClientState.PlaylistState:
                    PlaylistSelect();
                    break;
            }
    }

    #region Actions

    private void PlaySong()
    {
        Song song = SongSelectMenu();
        _musicPlayer.PlaySong(song);
    }

    private void AddSongToQueue()
    {
        Song song = SongSelectMenu();
        _musicPlayer.AppendQueue(song);
    }

    private void SkipSong()
    {
        _musicPlayer.SkipSong();
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

        User chosen = Input(users);
        if (chosen == _mainUser)
        {
            Console.WriteLine("Je kan jezelf niet als vriend toevoegen!");
            return;
        }
        friends.Add(chosen);
        Console.WriteLine("verzoek gestuurd naar " + chosen);
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
        User chosen = Input(friends);
        friends.Remove(chosen);
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

    private void CreatePlaylist()
    {
        Console.WriteLine("Vul een naam in voor de afspeellijst..");
        string input = Console.ReadLine() ?? throw new NullReferenceException();
        Playlist playlist = new(input);
        _mainUser.Playlists.Add(playlist);
        ModifyPlaylist(playlist);
    }

    private void EditPlaylist()
    {
        Playlist playlist = Input(_mainUser.Playlists);
        ModifyPlaylist(playlist);
    }

    private void ModifyPlaylist(Playlist playlist)
    {
        char input = '.';
        while (input != 'o')
        {
            Console.WriteLine(playlist.Name + '\n' + string.Join("\n", playlist.Songs) + '\n');
            
            input = Input(
                new CommandEntry('n', "Naam veranderen"),
                new CommandEntry('t', "Nummer toevoegen"),
                new CommandEntry('v', "Nummer verwijderen"),
                new CommandEntry('o', "Speellijst opslaan")
            );

            switch (input)
            {
                case 'n':
                    Console.WriteLine("Vul een naam in voor de afspeellijst..");
                    string newName = Console.ReadLine() ?? throw new NullReferenceException();
                    playlist.Rename(newName);
                    break;
                case 't':
                    Song newSong = Input(Song.GetAllSongs());
                    playlist.Add(newSong);
                    break;
                case 'v':
                    Song song = Input(playlist.Songs);
                    playlist.Remove(song);
                    break;
            }
        }
    }

    private void RemovePlaylist()
    {
        Console.WriteLine("Selecteer een afspeellijst...");
        _mainUser.Playlists.Remove(Input(_mainUser.Playlists));
    }


    private void ViewAlbumSongs()
    {
        Album selectedAlbum = AlbumSelectMenu();
        Console.WriteLine("Albums:" + selectedAlbum.Name);
    }
    private void AddFriendPlaylists()
    {
        Console.WriteLine("Kies een vriend:");

        User friend = Input(_mainUser.Friends);

        Console.WriteLine("Speellijsten van " + friend.Name + ":");

        Playlist playlist = Input(friend.Playlists);

        _mainUser.Playlists.Add(playlist);

        Console.WriteLine("Speellijst toegevoegd aan jouw speellijsten.");
    }

    #endregion

    #region State

    private void MainUserSelect()
    {
        Console.WriteLine("Kies de hoofdgebruiker!");

        _mainUser = UserSelectMenu();

        _state = ClientState.GeneralState;
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
            new CommandEntry('o', "Nummer overslaan"),
            new CommandEntry('w', "Nummer in wachtrij zetten"),
            new CommandEntry('c', "Laat alle artiesten zien"),
            new CommandEntry('v', "Laat alle vrienden zien"),
            new CommandEntry('l', "Laat alle albums zien"),
            new CommandEntry('p', "Beheer afspeellijsten"),
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
            case 'o':
                SkipSong();
                break;
            case 'w':
                AddSongToQueue();
                break;
            case 'c':
                ArtistSelectMenu();
                break;
            case 'v':
                _state = ClientState.FriendState;
                break;
            case 'u':
                Console.WriteLine("Uitgelogd!");
                _state = ClientState.MainUserSelectState;
                break;
            case 'p':
                _state = ClientState.PlaylistState;
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
        char input = Input(
            new CommandEntry('0', "Terug"),
            new CommandEntry('1', "Vrienden inzien"),
            new CommandEntry('2', "Vriend verzoek sturen"),
            new CommandEntry('3', "Vriend verwijderen"),
            new CommandEntry('4', "Speellijsten van een vriend toevoegen")
        );
        switch (input)
        {
            case '0':
                _state = ClientState.GeneralState;
                break;
            case '1':
                ViewFriends();
                break;
            case '2':
                AddFriend();
                break;
            case '3':
                RemoveFriend();
                break;
                case '4':
                ViewFriendPlaylists();
                break;
        }
    }

    private void PlaylistSelect()
    {
        char input = Input(
            new CommandEntry('t', "Terug"),
            new CommandEntry('m', "Speellijst maken"),
            new CommandEntry('b', "Speellijst bewerken"),
            new CommandEntry('v', "Speellijst verwijderen")
        );
        switch (input)
        {
            case 't':
                _state = ClientState.GeneralState;
                break;
            case 'm':
                CreatePlaylist();
                break;
            case 'b':
                EditPlaylist();
                break;
            case 'v':
                RemovePlaylist();
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

    private T Input<T>(IReadOnlyList<T> items)
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