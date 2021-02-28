using System;

namespace MorningRoutine
{
    /// <summary>
    /// 休日のルーティン
    /// </summary>
    public class HolidayRoutin : RoutinWorkBase
    {
        protected override void GetUp()
        {
            Console.WriteLine("7:00に起きる。");
        }

        protected override void Preparation()
        {
            Console.WriteLine("7:10分から準備します。");
        }
    }
}
