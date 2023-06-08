using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected List<EnemyController> enemies = new List<EnemyController>();

    public void AddEnemy(EnemyController enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemies.Remove(enemy);
    }

}
