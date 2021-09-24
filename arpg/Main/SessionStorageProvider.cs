using System.Collections.Generic;

namespace towerdef.Main
{
    public class SessionStorageProvider
    {
        public Dictionary<string, SessionStorageState> Storage { get; set; }

        public SessionStorageProvider()
        {
        }

        public void CreateNewSession(string key)
        {
            Storage = new Dictionary<string, SessionStorageState>
            {
                { key, new SessionStorageState() }
            };
        }

        public SessionStorageState GetFromSessionStorage(string key)
        {
            if (!Storage.ContainsKey(key))
                return null;

            return Storage[key];
        }
    }
}
