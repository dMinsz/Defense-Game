using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int hp;
    public int HP { get { return hp; } private set { hp = value; OnHpChanged?.Invoke(hp); } }

    public UnityEvent<int> OnHpChanged;
    public UnityEvent OnDied;

    private EnemyMover mover;

    private void Awake()
    {
        mover = GetComponent<EnemyMover>();
    }

    public void TakeHit(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            OnDied?.Invoke();
            mover.StopMove();
            Destroy(gameObject);
        }
    }
}
