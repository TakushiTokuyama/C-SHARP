using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

            var squares = Enumerable.Range(1, 7).Select(i => i * i).ToList();

            squares.ForEach(i => Console.WriteLine(i));

            
        }
    }
}
