using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject spawnPrefab;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 5.0f;
    public int maxEnemies = 8;
    public Transform enemyTarget;
    private float prevTime;
    private float spawnTime;

    void Start()
    {
        prevTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update () {
        if(Time.time - prevTime >= spawnTime)
        {
            SpawnItems();
            prevTime = Time.time;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
	}

    void SpawnItems()
    {
        if (spawnPrefab.tag == "Flying Enemy")
        {
            int nEnemies = GameObject.FindGameObjectsWithTag("Flying Enemy").Length;
            if (nEnemies < maxEnemies)
            {
                GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation);
                if ((enemyTarget != null) && (clone.GetComponent<FlyingEnemy>() != null))
                    clone.GetComponent<FlyingEnemy>().SetTarget(enemyTarget);
            }
        }
        else
            Instantiate(spawnPrefab, transform.position, transform.rotation);
    }
}
