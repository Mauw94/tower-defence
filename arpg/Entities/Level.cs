using System;

namespace towerdef.Entities
{
    public class Level
    {
        public int HealtPoints = 100;

        public static int Gold = 500;

        public static bool Buy(int cost)
        {
            if (Gold > cost)
            {
                Gold -= cost;
                return true;
            }


            return false;
        }

        public static void AddGold(int gold)
        {
            Gold += gold;
        }
    }
}
