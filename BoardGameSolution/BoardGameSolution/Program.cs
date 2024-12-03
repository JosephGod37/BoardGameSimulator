public class Player
{
    public string Name;
    public string Position;
    public int Score;

    public Player()
    {
        Name = "Unknown";
        Position = "Unknown";
        Score = 0;
    }
    public Player(string Name, string Position, int Score)
    {
        Name = this.Name;
        Position = this.Position;
        Score = this.Score;
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
       
    }
}