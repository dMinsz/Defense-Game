using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower
{
    public Transform magicPoint;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemies.Count > 0)
            {
                foreach (var e in enemies) 
                {
                    Attack(e);
                }

                yield return new WaitForSeconds(base.attackDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void Attack(EnemyController enemy)
    {
        MagicMissil missil = GameManager.Resource.Instantiate<MagicMissil>("Prefabs/MagicMissile", magicPoint.position, Quaternion.LookRotation(enemy.transform.position), true);
        missil.SetTarget(enemy);
        missil.SetDamage(base.attackDamage);
    }
}
