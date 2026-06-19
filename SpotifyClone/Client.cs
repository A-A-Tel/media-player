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
        char input = Input(
            new CommandEntry('s', "Laat alle nummers zien"),
            new CommandEntry('a', "Laat alle artiesten zien"),
             new CommandEntry('b', "Laat alle albums zien"),
             new CommandEntry('v', "Laat alle vrienden zien"),
            new CommandEntry('g', "Uitloggen")
        );

        switch (input)
        {

            case 's':
                SongSelectMenu();
                break;
            case 'a':
                ArtistSelectMenu();
                break;
            case 'v':
                FriendSelect();
                _state = ClientState.FriendSelect;
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
        char input = Input(
            new CommandEntry('0', "Terug"),
            new CommandEntry('1', "Vrienden inzien"),
            new CommandEntry('2', "Vriend verzoek sturen"),
            new CommandEntry('3', "Vriend verwijderen")
        );
        switch (input)
        {
            case '0':
                _state = ClientState.GeneralSelect;
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
        }
    }

    #endregion

    #region ActionMenus

    private Song SongSelectMenu()
    {
        List<Song> songs = Song.GetAllSongs();
        foreach (Song song in songs)
        {
            Console.WriteLine(song);
        }

        return null!;
    }
    private Artist ArtistSelectMenu()
    {
        Console.WriteLine("Artiesten:");
        List<Artist> artists = Artist.GetAllArtists();
        int index = Input(artists);

        return artists[index];
    }

    private User UserSelectMenu()
    {
        Console.WriteLine("Gebruikers:");
        List<User> users = User.GetAllUsers();
        int index = Input(users);
        
        return users[index];
    }

    private Album AlbumSelectMenu()
    {
        Console.WriteLine("Albums:");
        List<Album> albums = Album.GetAllAlbums();
        int index = Input(albums);

        return albums[index];
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

    private int Input<T>(List<T> items)
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