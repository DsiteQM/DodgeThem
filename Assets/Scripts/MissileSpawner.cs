    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject target;
    [SerializeField] private float spawnInterval = 10f;
  
    private float timer = 0f;

    void Update()
    {
        target = GameObject.Find("Plane");
        
        timer += Time.deltaTime;

        
        if (timer >= spawnInterval - (GameManager.Instance.gameSpeed / 10f) )
        {
            SpawnMissile();
            timer = 0f; 
        }
    }

    void SpawnMissile()
    {
        float spawnXDistance = 20f;
        float spawnYDistance = 30f;

        float spawnSide = Random.Range(0f, 1f);

        Vector3 spawnOffset = Random.insideUnitCircle * 5f;
        spawnOffset.z = 0f;

        Vector3 spawnXDirection = spawnSide < 0.5f ? -target.transform.right : target.transform.right;
        Vector3 spawnYDirection = spawnSide < 0.5f ? -target.transform.up : target.transform.up;

        Vector3 spawnPosition = target.transform.position + spawnOffset  + spawnXDirection * spawnXDistance + spawnYDirection *spawnYDistance;

        Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
    }
}
