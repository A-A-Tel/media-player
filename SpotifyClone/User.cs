namespace SpotifyClone;

public class User
{
    private string _name;
    public string Name => _name;

    public User(string name)
    {
        _name = name;
    }
}