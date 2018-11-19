using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Games.Data;
using Games.Models;

namespace Games.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class GamesService : IGamesService, IDisposable
    {
        private readonly GamesContext _context = new GamesContext();

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public bool DeleteGame(int id)
        {
            Game game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public bool UpdateGame(int id, string name)
        {
            Game game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                game.Name = name;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
