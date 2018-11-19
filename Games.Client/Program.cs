using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Client.GamesServices;

namespace Games.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Selection();
        }

        static void Selection()
        {
            while (true)
            {
                Console.WriteLine("Select option: 1. Show Games, 2. Add Game, 3. Edit Game, 4. Delete Game, 5. Quit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowGames();
                        break;
                    case "2":
                        AddGame();
                        break;
                    case "3":
                        EditGame();
                        break;
                    case "4":
                        DeleteGame();
                        break;
                    case "5":
                        return;
                    default:
                        break;
                }
            }
        }

        static void ShowGames()
        {
            GamesServiceClient proxy = new GamesServiceClient();
            List<Game> games = proxy.GetGames();
            foreach (var game in games)
            {
                Console.WriteLine(game.Id + ". " + game.Name);
            }
            proxy.Close();
        }

        static void AddGame()
        {
            GamesServiceClient proxy = new GamesServiceClient();
            Console.WriteLine("Enter Name Of Game");
            var name = Console.ReadLine();
            var game = new Game() { Name = name };
            proxy.AddGame(game);
            proxy.Close();
            Console.Clear();
            Console.WriteLine($"Game with name {name} added.");
        }

        static void EditGame()
        {
            GamesServiceClient proxy = new GamesServiceClient();
            Console.WriteLine("Enter Id Of Game");
            int Id = 0;
            try
            {
                Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid Id");
                return;
            }
            Console.WriteLine("Enter Name Of Game");
            var name = Console.ReadLine();
            try
            {
                proxy.UpdateGame(Id, name);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            proxy.Close();
            Console.Clear();
            Console.WriteLine($"Game with name {name} edited.");
        }

        static void DeleteGame()
        {
            GamesServiceClient proxy = new GamesServiceClient();
            Console.WriteLine("Enter Id Of Game");
            int Id = 0;
            try
            {
                Id = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid Id");
                return;
            }
            try
            {
                proxy.DeleteGame(Id);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            proxy.Close();
        }
    }
}
