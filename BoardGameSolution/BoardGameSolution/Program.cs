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
        int num = rnd.Next(1,7);
        Position += num;
        Console.WriteLine($"{Name} moved to position {Position}");
    }

    public void updatePoints()
    {
        Score += Position;
        Console.WriteLine("Score: {0}", Score);
    }
}

public class Board
{
    public int boardSize;
    public List<int> generatingRewards;
    private Random rnd = new Random();
    public Board()
    {
        boardSize = 30;
        rnd = new Random();
        generatingRewards = GenerateRandomRewards(12, boardSize);
    }
    public Board(int BoardSize)
    {
        this.boardSize = BoardSize;
        rnd = new Random();
        generatingRewards = GenerateRandomRewards(12, boardSize);
    }
    public void ExpandBoard(int newSize, int rewardsCount)
    {
        if (newSize <= boardSize)
        {
            throw new ArgumentException("New size must be larger than current size.");
        }

        boardSize = newSize;
        generatingRewards = GenerateRandomRewards(rewardsCount, boardSize);
    }
    private List<int> GenerateRandomRewards(int rewardsCount, int maxPosition)
    {
        var rewards = new HashSet<int>(); 

        while (rewards.Count < rewardsCount)
        {
            int randomPosition = rnd.Next(1, maxPosition + 1); 
            rewards.Add(randomPosition);
        }

        return new List<int>(rewards); 
    }
    
    
}
internal class Program
{
    public static void Main(string[] args)
    {
        var player = new Player();
        player.Move(); 
        player.updatePoints();
    }
}