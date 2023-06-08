using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyMover : MonoBehaviour
{
    public UnityEvent OnMoveStarted;
    public UnityEvent OnMoveEnded;
    public UnityEvent OnNextPointArrived;
    public UnityEvent OnEndPointArrived;

    private NavMeshAgent agent;
    private Transform[] wayPoints;
    private int curWayIndex;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[wayPoints.Length-1].position) < 0.2f) 
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameObject wayPoint = GameObject.FindGameObjectWithTag("WayPoint");
        wayPoints = wayPoint.GetComponent<WayPoint>().points;
        curWayIndex = 0;
        StartMove();
    }

    public void StartMove()
    {
        agent.destination = wayPoints[curWayIndex].position;
        moveRoutine = StartCoroutine(MoveRoutine());
        OnMoveStarted?.Invoke();
    }

    public void EndMove()
    {
        StopCoroutine(MoveRoutine());
        OnMoveEnded?.Invoke();
    }
    public void StopMove()
    {
        agent.isStopped = true;
        StopCoroutine(moveRoutine);
    }
    private void ToNextPoint()
    {
        agent.destination = wayPoints[curWayIndex].position;
        OnNextPointArrived?.Invoke();
    }

    private void OnArriveEndPoint()
    {
        Destroy(gameObject);
        OnEndPointArrived?.Invoke();
    }

    private Coroutine moveRoutine;
    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[curWayIndex].position) < 0.2f)
            {
                if (++curWayIndex < wayPoints.Length)
                {
                    ToNextPoint();
                }
                else
                {
                    OnArriveEndPoint();
                    yield break;
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
