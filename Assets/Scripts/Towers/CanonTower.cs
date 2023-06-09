using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    [SerializeField] Transform canonPoint;

    [SerializeField] float canonRange;

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
                Attack(enemies[0].transform.position);
                yield return new WaitForSeconds(attackDelay);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void Attack(Vector3 position)
    {
        CanonBall canonBall = GameManager.Resource.Instantiate<CanonBall>("Prefabs/CanonBall", canonPoint.position, Quaternion.identity);
        canonBall.SetTargetPosition(position);
        canonBall.SetDamage(attackDamage);
        canonBall.SetRange(canonRange);
    }
}
