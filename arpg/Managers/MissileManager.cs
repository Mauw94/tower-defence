using System.Collections.Generic;
using towerdef.Entities.Towers.Missiles;
using towerdef.Helpers;
using towerdef.Sprites;

namespace towerdef.Managers
{
    public class MissileManager : IGameManager
    {
        public static List<Missile> Missiles;

        public MissileManager()
        {
            Missiles = new List<Missile>();
        }

        public static Missile Generate(Sprite parent)
        {
            var missile = new FireMissile(TextureHelper.MissileTexture, parent);
            Missiles.Add(missile);

            return missile;
        }

        public static void Remove(Missile missile)
        {
            if (missile != null)
                Missiles.Remove(missile);
        }

        public void Reset()
        {
            Missiles = new List<Missile>();
        }
    }
}
