using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MagicMissil : MonoBehaviour
{
    [SerializeField] private float Speed;
    private EnemyController enemy;
    private int damage;

    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
    }
    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        StartCoroutine(MasicMissileRoutine(transform.position, enemy));
    }

    IEnumerator MasicMissileRoutine(Vector3 startPoint, EnemyController enemy)
    {
        Vector3 endPoint = enemy.transform.position;
        float time = Vector3.Distance(startPoint, endPoint) / Speed;

        float rate = 0f;
        while (rate < 1f)
        {
            rate += Time.deltaTime / time;

            if (enemy.IsValid())
            {
                transform.LookAt(enemy.transform.position);
                endPoint = enemy.transform.position;
            }

            transform.position = Vector3.Lerp(startPoint, endPoint, rate);
            yield return null;
        }

        transform.position = endPoint;
        yield return null;

        if (enemy.IsValid())
            enemy.TakeHit(damage);

        trail.Clear();
        GameManager.Resource.Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
