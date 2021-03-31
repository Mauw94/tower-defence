﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Entities.Towers;

namespace towerdef.Managers
{
    public class MissileManager
    {
        public List<Missile> Missiles;

        private Texture2D _missileTexture;

        public MissileManager(Texture2D missileTexture)
        {
            _missileTexture = missileTexture;
            Missiles = new List<Missile>();
        }

        public Missile Generate()
        {
            var missile = new Missile(_missileTexture);
            Missiles.Add(missile);

            return missile;
        }

        public void Remove(Missile missile)
        {
            if (missile != null)
                Missiles.Remove(missile);
        }
    }
}
