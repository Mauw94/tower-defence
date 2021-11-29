using System;
using towerdef.Entities.Towers.Missiles;
using towerdef.Entities.Towers.Missiles.Explosions;
using towerdef.Helpers;
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
                            {
                                ExplosionManager.Add(new Explosion(missile.Position, missile.Origin, 9));
                                EnemyManager.AoeHit(enemy, Missile.Damage);
                            }
                        } 
                        else
                        {
                            EnemyManager.Hit(enemy, Missile.Damage);
                        }
                        MissileManager.Remove(missile);
                    }
                }
            }
        }

        public void EnemyReachesEndCheck()
        {
            foreach (var enemy in EnemyManager.Enemies.ToArray())
            {
                // if (enemy.Position.X <= 0)
                // {
                //     Console.WriteLine("Enemy reached the end");
                //     enemy.IsRemoved = true;
                //     Level.Level1.Health -= 50;
                // }
            }
        }
    }
}
