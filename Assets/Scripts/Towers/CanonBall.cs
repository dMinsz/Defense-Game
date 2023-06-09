using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CanonBall : MonoBehaviour
{
    [SerializeField] float time;

    private TrailRenderer trail;
    private int damage;
    private float range;

    private ParticleSystem particle;
    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    public void SetTargetPosition(Vector3 position)
    {
        StartCoroutine(CanonRoutine(transform.position, position));
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetRange(float range)
    {
        this.range = range;
    }

    IEnumerator CanonRoutine(Vector3 startPoint, Vector3 endPoint)
    {
        float xSpeed = (endPoint.x - startPoint.x) / time;
        float zSpeed = (endPoint.z - startPoint.z) / time;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + startPoint.y) / time;

        float curTime = 0;
        while (curTime < time)
        {
            curTime += Time.deltaTime;

            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;

            yield return null;
        }

        transform.position = endPoint;
        yield return null;

        Explosion();
        trail.Clear();
        particle.Play();
        yield return new WaitForSeconds(1.0f);

        GameManager.Resource.Destroy(gameObject);
    }

    public void Explosion()
    {
        

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            EnemyController enemy = collider.GetComponent<EnemyController>();
            enemy?.TakeHit(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
