using SpotifyClone.Entities;

namespace SpotifyClone
{
    public class Client
    {
        public void SongSelectMenu(List<Song> songs)
        {
            Console.WriteLine("Nummers:");

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title);
            }
            Console.WriteLine();
            Console.WriteLine("Type a song name:");

            string songName = Console.ReadLine();

            Console.WriteLine("You selected: " + songName);
        }
        public void ShowArtists(List<Artist> artists)
        {
            Console.WriteLine("Artiesten:");

            foreach (Artist artist in artists)
            {
                Console.WriteLine(artist.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Type an artist name:");

            string artistName = Console.ReadLine();

            Console.WriteLine("You selected: " + artistName);
        }
    }
}