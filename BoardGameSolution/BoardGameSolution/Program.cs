using System.Runtime.CompilerServices;
using BoardGameSolution;


public class Board
{
    public int boardSize;
    public List<int> generatingRewards;
    public List<int> generatingBomb;
    private Random rnd = new Random();
    public Board()
    {
        boardSize = 30;
        rnd = new Random();
        generatingRewards = GenerateRandomRewards(12, boardSize);
        generatingBomb = GenerateBomb(12, boardSize);
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
    
    private List<int> GenerateBomb(int bombCount, int maxPosition)
    {
        var bomb = new HashSet<int>(); 

        while (bomb.Count < bombCount)
        {
            int randomPosition = rnd.Next(1, maxPosition + 1); 
            bomb.Add(randomPosition);
        }

        return new List<int>(bomb); 
    }
    
    public bool HasBombAt(int position)
    {
        return  generatingBomb.Contains(position); 
    }
    
    public void RemoveBomb(int position)
    {
        generatingBomb.Remove(position); 
    }
}

public class Game
{
    private Board board;
    private List<Player> players;
    private int currentPlayerIndex;

    public void StartGame()
    {
        
        Console.WriteLine("Czy chcesz powiększyć mapę? (standardowy rozmiar to 30) t/n");
        string choice = Console.ReadLine();

        if (choice == "n")
        {
            board = new Board(); 
            Console.WriteLine($"Rozmiar mapy to: {board.boardSize}");
        }
        else
        {
            Console.WriteLine("Podaj rozmiar mapy (musi być większa niż 30)");
            string choice2 = Console.ReadLine();

            int number;

            if (int.TryParse(choice2, out number) && number > 30)
            {
                board = new Board(number);
                Console.WriteLine($"Rozmiar mapy to: {board.boardSize}");
            }
            else
            {
                Console.WriteLine("Błędny rozmiar mapy! Ustawiono domyślny rozmiar 30.");
                board = new Board();  
                Console.WriteLine($"Rozmiar mapy to: {board.boardSize}");
            }
        }

     
        Console.WriteLine("Podaj liczbę graczy (maksymalnie 2):");
        int playerCount;

        while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 1 || playerCount > 2)
        {
            Console.WriteLine("Niepoprawna liczba graczy. Proszę podać liczbę graczy (1 lub 2):");
        }

        players = new List<Player>();

        
        for (int i = 0; i < playerCount; i++)
        {
            Console.WriteLine($"Podaj imię gracza {i + 1}:");
            string playerName = Console.ReadLine();
            players.Add(new Magician(playerName, 0, 0));  
        }

        Console.WriteLine($"Rozpoczynasz grę z {playerCount} graczami.");

        currentPlayerIndex = 0;  

        Console.WriteLine("Wybierz role (magician,healer,warrior");
        string choice3 = Console.ReadLine();
        
        if (choice3 == "magician")
        {
            while (true)
            {
                Player currentPlayer = players[currentPlayerIndex];

           
                Console.WriteLine($"\nGracz: {currentPlayer.Name}, Pozycja: {currentPlayer.Position}, Wynik: {currentPlayer.Score}");

           
                Console.WriteLine($"{currentPlayer.Name}, czy chcesz się ruszyć? (t/n)");
                string moveChoice = Console.ReadLine();

                if (moveChoice.ToLower() == "t")
                {
                
                    currentPlayer.Move();
                
                    ((Magician)currentPlayer).CheckReward(board);
                
                    currentPlayer.CheckBomb(board);

                
                    if (currentPlayer.Position >= board.boardSize)
                    {
                        EndGame();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.Name} postanowił pominąć turę.");
                }

            
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
        }
        else if (choice3 == "warrior")
        {
            while (true)
            {
                Player currentPlayer = players[currentPlayerIndex];

           
                Console.WriteLine($"\nGracz: {currentPlayer.Name}, Pozycja: {currentPlayer.Position}, Wynik: {currentPlayer.Score}");

           
                Console.WriteLine($"{currentPlayer.Name}, czy chcesz się ruszyć? (t/n)");
                string moveChoice = Console.ReadLine();

                if (moveChoice.ToLower() == "t")
                {
                
                    currentPlayer.Move();
                
                    ((Warrior)currentPlayer).CheckReward(board);
                
                    currentPlayer.CheckBomb(board);

                
                    if (currentPlayer.Position >= board.boardSize)
                    {
                        EndGame();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.Name} postanowił pominąć turę.");
                }

            
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
            
        }
        else if (choice3 == "warrior")
        {
            while (true)
            {
                Player currentPlayer = players[currentPlayerIndex];


                Console.WriteLine(
                    $"\nGracz: {currentPlayer.Name}, Pozycja: {currentPlayer.Position}, Wynik: {currentPlayer.Score}");


                Console.WriteLine($"{currentPlayer.Name}, czy chcesz się ruszyć? (t/n)");
                string moveChoice = Console.ReadLine();

                if (moveChoice.ToLower() == "t")
                {

                    currentPlayer.Move();

                    ((Warrior)currentPlayer).CheckReward(board);

                    currentPlayer.CheckBomb(board);


                    if (currentPlayer.Position >= board.boardSize)
                    {
                        EndGame();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.Name} postanowił pominąć turę.");
                }


                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
        }
        // while (true)
        // {
        //     Player currentPlayer = players[currentPlayerIndex];
        //
        //    
        //     Console.WriteLine($"\nGracz: {currentPlayer.Name}, Pozycja: {currentPlayer.Position}, Wynik: {currentPlayer.Score}");
        //
        //    
        //     Console.WriteLine($"{currentPlayer.Name}, czy chcesz się ruszyć? (t/n)");
        //     string moveChoice = Console.ReadLine();
        //
        //     if (moveChoice.ToLower() == "t")
        //     {
        //         
        //         currentPlayer.Move();
        //         
        //         ((Magician)currentPlayer).CheckReward(board);
        //         
        //         currentPlayer.CheckBomb(board);
        //
        //         
        //         if (currentPlayer.Position >= board.boardSize)
        //         {
        //             EndGame();
        //             return;
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{currentPlayer.Name} postanowił pominąć turę.");
        //     }
        //
        //     
        //     currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        // }
    }

    private void EndGame()
    {
        Console.WriteLine("\nKoniec gry!");
        foreach (var player in players)
        {
            Console.WriteLine($"Gracz {player.Name}: {player.Score} punktów.");
        }

        
        if (players.Count == 2)
        {
            Player winner = players[0].Score > players[1].Score ? players[0] : players[1];
            Console.WriteLine($"Zwycięzca: {winner.Name}!");
        }
    }
}





internal class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.StartGame();
    }
    
}