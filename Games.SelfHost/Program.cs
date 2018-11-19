using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Games.Services;

namespace Games.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(GamesService));
                host.Open();
                Console.WriteLine(host.State);
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
                host.Close();
                Console.WriteLine(host.State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
