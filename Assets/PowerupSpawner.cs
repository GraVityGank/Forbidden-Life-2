using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float spawnRadius = 7, time = 1.5f;
    public Transform Player;
    public GameObject[] powers;

    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(powers[Random.Range(0, powers.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
