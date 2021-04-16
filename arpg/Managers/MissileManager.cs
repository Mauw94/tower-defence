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

        public static Missile Generate(Sprite parent, MissileType type)
        {
            var missile = CreateMissileFromType(parent, type);
            Missiles.Add(missile);

            return missile;
        }

        public static void Remove(Missile missile)
        {
            if (missile != null && Missiles.Contains(missile))
                Missiles.Remove(missile);
        }

        public void Reset()
        {
            Missiles = new List<Missile>();
        }

        static Missile CreateMissileFromType(Sprite parent, MissileType type)
        {
            return type switch
            {
                MissileType.Basic => new BasicMissile(TextureHelper.MissileTexture, parent),
                MissileType.Fire => new FireMissile(TextureHelper.FireMissileTexture, parent),
                MissileType.Frost => new FrostMissile(TextureHelper.MissileTexture, parent),
                _ => null,
            };
        }
    }
}
