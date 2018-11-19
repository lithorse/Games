using Games.Models;
using System;
using System.Data.Entity;

namespace Games.Data
{
    public class GamesContext : DbContext
    {
        public GamesContext() : base("GamesDb")
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
