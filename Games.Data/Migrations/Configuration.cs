namespace Games.Data.Migrations
{
    using Games.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Games.Data.GamesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Games.Data.GamesContext context)
        {
            context.Games.AddOrUpdate(
                s => s.Name,
                new Game { Name = "Undertale" },
                new Game { Name = "Deltarune" }
            );
        }
    }
}
