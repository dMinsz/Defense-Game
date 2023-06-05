using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ���� �߻���
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; // ���� ��ġ
    [SerializeField] private float spawnTime; // ���� ������
    [SerializeField] private GameObject enemyPrefab; // ������ ���� ������

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
