namespace SpotifyClone.Entities;

public class Song
{
    public string Name { get; private set; }
    public double Duration { get; private set; }
    public DateOnly Releasedate { get; private set; }
    public List<Artist> Artists { get; private set; }

    public Song(string name, List<Artist> artists, double duration, DateOnly releasedate)
    {
        Name = name;
        Artists = artists;
        Duration = duration;
        Releasedate = releasedate;
    }

    public static List<Song> GetAllSongs()
    {
        throw new NotImplementedException();
    }
}