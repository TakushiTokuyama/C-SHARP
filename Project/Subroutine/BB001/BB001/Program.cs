using System;

namespace BB001
{
    class Program
    {
        static void Main(string[] args)
        {
            BB001Service service = new BB001Service();

            var list = service.LeaderBoardAndPlayers();

            list.ForEach(l =>
            {            
                Console.WriteLine("LeaderNum:{0}" + "TeamName:{1}" + "WinRate:{2}" + "Name:{3}",l.LeaderNum,l.TeamName, l.WinRate, l.Name);
            });
        }
    }
}
