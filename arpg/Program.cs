﻿using System;

namespace towerdef
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new TowerDefence())
                game.Run();
        }
    }
}
