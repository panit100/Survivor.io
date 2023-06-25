using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPooling : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPool
    {
        public string tag;
        public GameObject enemyPrefab;
        public int amount;
    }

    public float spawnOffset = 1f;
    public Transform player;

    public List<EnemyPool> enemyPoolList;
    public Dictionary<string,Queue<GameObject>> enemyPoolDictionary;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        enemyPoolDictionary = new Dictionary<string, Queue<GameObject>>();
    
        foreach(EnemyPool pool in enemyPoolList)
        {
            Queue<GameObject> enemyPool = new Queue<GameObject>();

            for(int i = 0; i < pool.amount; i++)
            {
                GameObject enemy = Instantiate(pool.enemyPrefab);
                enemy.SetActive(false);
                enemyPool.Enqueue(enemy);
            }

            enemyPoolDictionary.Add(pool.tag,enemyPool);
        }
    }

    void SpawnEnemyFromPool(string tag)
    {
        GameObject enemyToSpawn = enemyPoolDictionary[tag].Dequeue();

        GameObject _enemy = Instantiate(enemyToSpawn,RandomSpawnPosition(),Quaternion.identity); //spawn enemy with random position function
    
        enemyPoolDictionary[tag].Enqueue(enemyToSpawn);
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        return offScreenPosition;
    }
}
