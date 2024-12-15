namespace BoardGameSolution;

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
        Console.WriteLine($"{Name} moved to position {Position}, dostaje zatem {num} punktow.");
        Score += num;
    }

    public void updatePoints()
    {
        Console.WriteLine("Score: {0}", Score);
    }

     /*public void CheckReward(Board board)
     {
         if (board.HasRewardAt(Position))
        {
            Score += 2;
            Console.WriteLine(
                $"Gracz: {Name} znalazl nagorde na pozycji: {Position}! dostaje plus 2 punkty, Score: {Score}");
            board.RemoveReward(Position);
        }
     }*/
    /*public void CheckBomb(Board board)
    {
        if (board.HasBombAt(Position))
        {
            Score -= 2;
            Console.WriteLine(
                $"Gracz: {Name} znalazl bombe na pozycji: {Position}! dostaje minus 2 punkty, Score: {Score}");
            board.RemoveBomb(Position);
        }
    }*/
}