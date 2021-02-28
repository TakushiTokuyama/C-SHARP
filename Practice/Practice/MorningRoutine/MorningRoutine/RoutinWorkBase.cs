using System;

namespace MorningRoutine
{
    /// <summary>
    /// ルーティーン基底クラス
    /// </summary>
    public abstract class RoutinWorkBase
    {

        /// <summary>
        /// ルーティーン分岐
        /// </summary>
        public static void RoutinWork(bool isFolidayFlg)
        {
            if (isFolidayFlg)
            {
                new HolidayRoutin().Start(isFolidayFlg);
            }
            else
            {
                new WeekdaysRoutin().Start(isFolidayFlg);
            }
        }

        /// <summary>
        /// ルーティーンスタート
        /// </summary>
        public void Start(bool isFolidayFlg)
        {
            // 起床
            GetUp();

            // 準備
            Preparation();

            if (isFolidayFlg)
            {
                // まったり
                Relax();
            }
            else
            {
                // 出勤
                Commuting();
            }
        }

        // 起床
        protected abstract void GetUp();

        // 準備
        protected abstract void Preparation();

        // 出勤
        protected virtual void Commuting()
        {
            Console.WriteLine("出勤します。");
        }

        // まったり
        protected virtual void Relax()
        {
            Console.WriteLine("まったりします。");
        }
    }
}
