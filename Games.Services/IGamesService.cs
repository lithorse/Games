using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Games.Models;

namespace Games.Services
{
    [ServiceContract]
    public interface IGamesService
    {
        [OperationContract]
        List<Game> GetGames();
        [OperationContract]
        void AddGame(Game game);
        [OperationContract]
        bool UpdateGame(int id, string name);
        [OperationContract]
        bool DeleteGame(int id);
    }
}
