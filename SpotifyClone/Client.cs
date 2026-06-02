using SpotifyClone.Entities;

namespace SpotifyClone
{
    public class Client
    {
        public void ShowSongs(List<Song> songs)
        {
            Console.WriteLine("Nummers:");

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}