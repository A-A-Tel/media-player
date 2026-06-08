namespace SpotifyClone;

public class Client
{
    
    private List<User> _users = new List<User>
    {
        new User("Jan"),
        new User("Jan2"),
        new User("Jan3"),
        new User("Jan4")
    };
    public void MainUserSelect()
    {
        while (true)
        {
            bool beantwoord = false;
            while (beantwoord == false)
            {
                Console.WriteLine("Kies de hoofdgebruiker!");
                for (int i = 0; i < _users.Count; i++)
                {
                    Console.WriteLine($"{_users[i].Name} [{i + 1}]");
                }
            
                string invoer = Console.ReadLine();
                int keuze = int.Parse(invoer);

                if (keuze >= 1 && keuze <= _users.Count)
                {
                    User gekozen = _users[keuze - 1];
                    Console.WriteLine($"Hallo {gekozen.Name}");
                    beantwoord = true;
                }
                else
                {
                    Console.WriteLine("Geen geldig antwoord");
                }
            }
            Console.WriteLine("Luisteren [1]");
            Console.WriteLine("Uitloggen [2]");
            string keuze2 = Console.ReadLine();
            if (keuze2 == "1")
            {
                break;
            }
        }
    }
}