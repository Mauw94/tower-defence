using System.Collections.Generic;
using towerdef.Managers;

namespace towerdef.Entities.Towers.Missiles.Explosions
{
    public class ExplosionManager : IGameManager
    {
        public static List<Explosion> Explosions;

        public ExplosionManager()
        {
            Explosions = new List<Explosion>();
        }

        public static void Add(Explosion explosion)
        {
            Explosions.Add(explosion);
        }

        public static void Remove(Explosion explosion)
        {
            if (explosion != null && Explosions.Contains(explosion))
                Explosions.Remove(explosion);
        }

        public void Reset()
        {
            Explosions = new List<Explosion>();
        }
    }
}
