namespace SpotifyClone.Entities;

public class Song
{
    private readonly static List<Song> _songs =
        [
            new("Bohemian Rhapsody", [new Artist("Queen")], 355, DateOnly.Parse("1975-10-31")),
            new(@"Stairway to Heaven", [new Artist("Led Zeppelin")], 482, DateOnly.Parse("1971-11-08")),
            new("Hotel California", [new Artist("Eagles")], 390, DateOnly.Parse("1976-12-08")),
        ];

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
        return _songs;
    }


    public override string ToString()
    {
        return Name + " - " + string.Join(", ", Artists) + " - " + Duration + " - " + Releasedate;
    }
}