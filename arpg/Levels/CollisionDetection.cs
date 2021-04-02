using towerdef.Entities.Towers;
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
                        MissileManager.Remove(missile);
                        EnemyManager.Hit(enemy, Missile.Damage);
                    }
                }
            }
        }
    }
}
