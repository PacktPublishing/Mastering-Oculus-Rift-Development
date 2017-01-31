using System.Collections.Generic;

public class Enemy
{
    public int health;
    public bool isAttacking;
    public void UpdateEnemy()
    {
        return;
    }
}

public class EnemyPool
{
    Stack<Enemy> pool;
    public Enemy GetEnemy()
    {
        if(pool.Count == 0)
        {
            return new Enemy();
        }
        else
        {
            return pool.Pop();
        }
    }
}