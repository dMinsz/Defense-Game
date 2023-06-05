using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//적 몬스터 발생기
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // 스폰 위치
    [SerializeField] private float spawnTime; // 스폰 딜레이
    [SerializeField] private GameObject enemyPrefab; // 스폰할 몬스터 프리팹

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    Coroutine spawnRoutine;
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
