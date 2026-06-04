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
        }
        public void ShowArtists(List<Artist> artists)
        {
            Console.WriteLine("Artiesten:");

            foreach (Artist artist in artists)
            {
                Console.WriteLine(artist.Name);
            }
        }
    }
}