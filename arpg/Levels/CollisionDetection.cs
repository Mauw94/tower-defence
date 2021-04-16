using towerdef.Entities.Towers.Missiles;
using towerdef.Entities.Towers.Missiles.Explosions;
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
                                // todo: hit enemies in radius, do less dmg to aoe targets
                                ExplosionManager.Add(new Explosion(missile.Position, missile.Origin, 9));
                                EnemyManager.AoeHit(enemy, FireMissile.Damage);
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
    }
}
