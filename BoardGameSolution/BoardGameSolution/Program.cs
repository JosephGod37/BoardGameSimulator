using System.Runtime.CompilerServices;

public class Player
{
    public string Name;
    public int Position;
    public int Score;

    public Player()
    {
        Name = "Unknown";
        Position = 0;
        Score = 0;
    }
    public Player(string name, int position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }

    public void Move()
    {
        Random rnd = new Random();
        int num = rnd.Next(0,7);
        Position += num;
        
    }
    public void DisplayInformation()
    {
        Console.WriteLine($"Position: {Position}");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var player = new Player();
        
        while (player.Position != 10)
        {
            player.Move();            
            player.DisplayInformation(); 
        }
        
        Console.WriteLine("Player reached position 10!");
        
        
    }
}