using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;

    private TrailRenderer trail;
    private EnemyController enemy;
    private int damage;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        StartCoroutine(ArrowRoutine(transform.position, enemy));
    }

    IEnumerator ArrowRoutine(Vector3 startPoint, EnemyController enemy)
    {
        Vector3 endPoint = enemy.transform.position;
        float time = Vector3.Distance(startPoint, endPoint) / arrowSpeed;

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
