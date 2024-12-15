namespace BoardGameSolution;

public class Warrior: Player, ISetPoints
{
    public Warrior(string name, int position, int score) : base(name, position, score)
    {
    }

    public void CheckReward(Board board)
    {
        if (board.HasRewardAt(Position))
        {
            Score += 3;
            Console.WriteLine(
                $"Gracz: {Name} znalazl nagorde na pozycji: {Position}! dostaje plus 3 punkty, Score: {Score}");
            board.RemoveReward(Position);
        }
    }

    public void CheckBomb(Board board)
    {
        if (board.HasBombAt(Position))
        {
            Score -= 1;
            Console.WriteLine($"Gracz: {Name} znalazl bombe na pozycji: {Position}! dostaje minus 1 punkty, Score: {Score}");
            board.RemoveBomb(Position);
        }
    }
    
}