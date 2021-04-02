using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
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

        public static void Remove(Enemy enemy)
        {
            if (enemy != null)
                Enemies.Remove(enemy);
        }

        public static void Hit(Enemy enemy, int damage)
        {
            enemy.HealthPoints -= damage;
            if (!enemy.IsAlive())
                Remove(enemy);
        }

        // todo: AI pathing for enemies.
    }
}