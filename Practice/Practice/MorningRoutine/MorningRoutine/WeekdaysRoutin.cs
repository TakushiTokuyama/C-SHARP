using System;

namespace MorningRoutine
{
    /// <summary>
    /// 平日のルーティン
    /// </summary>
    public class WeekdaysRoutin : RoutinWorkBase
    {
        protected override void GetUp()
        {
            Console.WriteLine("7:30に起きる。");
        }

        protected override void Preparation()
        {
            Console.WriteLine("7:40分から準備します。");
        }

        protected override void Commuting()
        {
            base.Relax();
        }
    }
}
