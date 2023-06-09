using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected List<EnemyController> enemies = new List<EnemyController>();

    [HideInInspector] public int attackDamage;
    [HideInInspector] public float attackDelay;

    public void AddEnemy(EnemyController enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemies.Remove(enemy);
    }

}
