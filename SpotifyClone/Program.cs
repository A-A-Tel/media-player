using SpotifyClone.Entities;
namespace SpotifyClone;

public class Program
{
    public static void Main(string[] args)
    {
        Client client = new();
        client.Start();
    }
}