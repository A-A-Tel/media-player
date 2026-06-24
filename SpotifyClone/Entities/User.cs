namespace SpotifyClone.Entities;

public class User
{
    private static readonly List<User> Users = [new("John"), new("Jane"), new("Joe"), new("Jeff")];

    public string Name { get; private set; }

    public List<User> Friends { get; private set; } = [];
    
    
    public List<Playlist> Playlists { get; private set; } = [];


    public User(string name)
    {
        Name = name;
    }

    public static List<User> GetAllUsers()
    {
        return Users;
    }

    public override string ToString()
    {
        return Name;
    }
}