namespace BoardGameSolution;

public class Healer : Player, ISetPoints
{
    public Healer(string name, int position, int score) : base(name, position, score)
    {
    }

    public void CheckReward(Board board)
    {
        if (board.HasRewardAt(Position))
        {
            Score += 2;
            Console.WriteLine($"Gracz: {Name} znalazl nagorde na pozycji: {Position}! dostaje plus 2 punkty, Score: {Score}");
            board.RemoveReward(Position);
        }
            
    }
    public void CheckBomb(Board board)
    {
        if (board.HasBombAt(Position))
        {
            Score -= 0;
            Console.WriteLine(
                $"Gracz: {Name} znalazl bombe na pozycji: {Position}! dostaje minus 0 punkty, Score: {Score}");
            board.RemoveBomb(Position);
        }
    }
    
}