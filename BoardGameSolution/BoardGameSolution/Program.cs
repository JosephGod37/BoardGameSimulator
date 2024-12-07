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
        Score += num;
    }

    public void updatePoints()
    {
        Score += Position;
        Console.WriteLine("Score: {0}", Score);
    }

    public void CheckReward(Board board)
    {
        if (board.HasRewardAt(Position))
        {
            Score += 2;
            Console.WriteLine(
                $"Gracz: {Name} znalazl nagorde na pozycji: {Position}! dostaje plus 2 punkty, Score: {Score}");
            board.RemoveReward(Position);
        }
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
            throw new ArgumentException("Nowy rozmiar musi byc wiekszy niz 30 pól");
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
    public bool HasRewardAt(int position)
    {
        return generatingRewards.Contains(position); 
    }
    
    public void RemoveReward(int position)
    {
        generatingRewards.Remove(position); 
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var board = new Board();
        var player = new Player("Alice", 0, 0);

        Console.WriteLine($"Initial rewards: {string.Join(", ", board.generatingRewards)}");

        
        for (int i = 0; i < 10; i++) 
        {
            player.Move();
            player.CheckReward(board); 
        }

        Console.WriteLine($"Final Score: {player.Score}");
    }
    
}