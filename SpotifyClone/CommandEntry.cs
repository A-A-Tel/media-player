namespace SpotifyClone;

public struct CommandEntry
{
    public readonly char Key;
    public readonly string Description;

    public CommandEntry(char key, string description)
    {
        Key = key;
        Description = description;
    }
}