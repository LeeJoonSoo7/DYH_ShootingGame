using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject prefab_enemy;

    private void Start()
    {
        StartCoroutine("OnSpawnerStart");
    }

    private void SpawnEnemyOnce()
    {
        int _posIndex = Random.Range(0, spawnPoints.Length);

        Transform _tr = spawnPoints[_posIndex];
        Instantiate(prefab_enemy, _tr.position, Quaternion.identity);
    }

    private IEnumerator OnSpawnerStart()
    {
        yield return null;
        while (true)
        {
            SpawnEnemyOnce();
            yield return new WaitForSeconds(1.0f);
        }
    }
}
