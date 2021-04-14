using System;
using towerdef.Entities.Towers.Missiles;
using towerdef.Managers;

namespace towerdef.Levels
{
    public class CollisionDetection
    {
        public CollisionDetection()
        {

        }

        public void DetectCollision()
        {
            foreach (var missile in MissileManager.Missiles.ToArray())
            {
                foreach (var enemy in EnemyManager.Enemies.ToArray())
                {
                    if (missile.Rectangle.Intersects(enemy.Rectangle))
                    {
                        if (missile.HasSpecialAbility)
                        {
                            if (missile is FireMissile)
                                Console.WriteLine("do special things");
                        }
                        MissileManager.Remove(missile);
                        EnemyManager.Hit(enemy, Missile.Damage);
                    }
                }
            }
        }
    }
}
