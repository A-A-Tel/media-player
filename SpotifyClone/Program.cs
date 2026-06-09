using SpotifyClone.Entities;
namespace SpotifyClone;

public class Program
{
    public static void Main(string[] args)
    {
        // Artist artist1 = new Artist("The Weeknd");
        // Artist artist2 = new Artist("Drake");
        //
        // List<Artist> artists = new List<Artist>();
        // artists.Add(artist1);
        // artists.Add(artist2);
        //
        // List<Song> songs = new List<Song>();
        // songs.Add(new Song("Starboy", artist1, 3.5, "Pop", "2016"));
        // songs.Add(new Song("God's Plan", artist2, 3.2, "Rap", "2018"));
        //
        // Client client = new Client();
        //
        // Console.WriteLine("Welcome to Spotify!");
        // Console.WriteLine("Type a command:");
        //
        //
        // string command = Console.ReadLine();
        //
        // if (command == "nummers")
        // {
        //     client.SongSelectMenu(songs);
        // }
        // else if (command == "artiesten")
        // {
        //     client.ShowArtists(artists);
        // }
        // else
        // {
        //     Console.WriteLine("Unknown command");
        // }
        
        Client client = new();
        client.Start();
    }
}