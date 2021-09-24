using System;

namespace towerdef.Main
{
    public class SessionStorageState
    {
        // Session info.
        private DateTime _created;

        // Game info.
        public int TowersBuilt { get; set; }
        public int EnemiesSpawned { get; set; }
        public int EnemiesKilled { get; set; }
        public int GoldSpent { get; set; }
        public int GoldEarned { get; set; }

        public SessionStorageState()
        {
            _created = DateTime.Now;
        }
    }
}
