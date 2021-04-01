using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Entities.Enemies;

namespace towerdef.Managers
{
    public class EnemyManager
    {
        public static List<Enemy> Enemies;

        public EnemyManager()
        {
            Enemies = new List<Enemy>();
        }

        public static BasicSkeleton GenerateSkeleton(Texture2D skeletonTexture)
        {
            var skeleton = new BasicSkeleton(skeletonTexture);
            Enemies.Add(skeleton);

            return skeleton;
        }

        // todo: AI pathing for enemies.
    }
}