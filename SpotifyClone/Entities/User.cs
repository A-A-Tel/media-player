namespace SpotifyClone.Entities;

public class User
{
    private static readonly List<User> Users = [new("John"), new("Jane"), new("Joe"), new("Jeff")];

    public string Name { get; private set; }

    private static readonly List<User> Friends = [new("Regu larjoe"), new("Jeff")];

    public List<Playlist> Playlists { get; private set; } = [];

    public User(string name)
    {
        Name = name;
    }

    public static List<User> GetAllUsers()
    {
        return Users;
    }
    
    public static List<User> GetAllFriends()
    {
        return Friends;
    }

    public override string ToString()
    {
        return Name;
    }
}