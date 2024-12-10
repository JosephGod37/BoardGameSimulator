namespace BoardGameSolution;

public class Magician: Player, ISetPoints
{
    public Magician(string name, int position, int score) : base(name, position, score)
    {
    }

    public void CheckReward(Board board)
    {
        if (board.HasRewardAt(Position))
        {
            Score += 3;
            Console.WriteLine(
                $"Gracz: {Name} znalazl nagorde na pozycji: {Position}! dostaje plus 2 punkty, Score: {Score}");
            board.RemoveReward(Position);
        }
    }
}