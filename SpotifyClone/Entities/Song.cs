namespace SpotifyClone.Entities;

public class Song
{
    private static readonly List<Song> Songs =
    [
        new("Cartoon", "cartoon.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[0],
            [Artist.GetAllArtists()[0]]),
        
        new("Hellcat", "hellcat.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[0],
            [Artist.GetAllArtists()[0]]),
        
        new("Hello", "hello.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[0],
            [Artist.GetAllArtists()[0]]),
        
        
        new("Frank Sinatra vs Freddie Mercury", "frankvsfreddie.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[1],
            [Artist.GetAllArtists()[1]]),
        
        new("Michael Jackson vs Elvis Presley", "michaelvselvis.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[1],
            [Artist.GetAllArtists()[1]]),
        
        new("Mr Beast vs Squid Game", "mrvssquid.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[1],
            [Artist.GetAllArtists()[1]]),
        
        
        new("Monkeys spinning monkeys", "monkeys.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[2],
            [Artist.GetAllArtists()[2]]),
        
        new("Nyan cat", "nyan.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[2],
            [Artist.GetAllArtists()[3]]),
        
        new("Pen pineapple apple pen", "pen.mp3",
            new DateOnly(2025, 06, 11), Album.GetAllAlbums()[2],
                [Artist.GetAllArtists()[4]]),
    ];

    public string Name { get; private set; }
    public string FileName { get; private set; }
    public DateOnly Releasedate { get; private set; }
    public Album Album { get; private set; }
    public List<Artist> Artists { get; private set; }

    public Song(string name, string fileName, DateOnly releasedate, Album album, List<Artist> artists)
    {
        Name = name;
        FileName = fileName;
        Releasedate = releasedate;
        Album = album;
        Artists = artists;
    }

    public static List<Song> GetAllSongs()
    {
        return Songs;
    }


    public override string ToString()
    {
        return Name + " - " + Album.Name + " - " + string.Join(", ", Artists) + " - " + Releasedate;
    }
}