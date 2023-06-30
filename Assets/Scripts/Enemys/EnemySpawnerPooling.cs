using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPool
{
    public string tag;
    public EnemyScript enemyPrefab;
    public int amount;
}

public class EnemySpawnerPooling : MonoBehaviour
{
    public float spawnOffset = 1f;
    public Transform player;

    public float gameTime;
    public List<EnemySet> enemySet = new List<EnemySet>();

    [HideInInspector]
    public List<GameObject> enemyContainer = new List<GameObject>();
    float enemySpawnAmount; //when start new wave add enemySpawnAmount

    public List<EnemyPool> enemyPoolList;
    public Dictionary<string,Queue<EnemyScript>> enemyPoolDictionary;
    
    void Start()
    {
        InitializePool();

        enemySpawnAmount = 10;

        InvokeRepeating("SpawnSequence",1f ,1f);
    }

    void CountTime()
    {
        gameTime += 1;
    }

    void InitializePool()
    {
        enemyPoolDictionary = new Dictionary<string, Queue<EnemyScript>>();
    
        foreach(EnemyPool pool in enemyPoolList)
        {
            Queue<EnemyScript> enemyPool = new Queue<EnemyScript>();

            for(int i = 0; i < pool.amount; i++)
            {
                EnemyScript enemy = Instantiate(pool.enemyPrefab);
                enemy.enemySpawner = this;
                enemy.gameObject.SetActive(false);
                enemyPool.Enqueue(enemy);
            }

            enemyPoolDictionary.Add(pool.tag,enemyPool);
        }
    }

    void SpawnEnemyFromPool(string tag)
    {
        EnemyScript enemyToSpawn = enemyPoolDictionary[tag].Dequeue();

        enemyToSpawn.transform.position = RandomSpawnPosition();
        enemyToSpawn.gameObject.SetActive(true);
        enemyToSpawn.SetupComponent();

        enemyPoolDictionary[tag].Enqueue(enemyToSpawn);

        enemyContainer.Add(enemyToSpawn.gameObject);
    }

    Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.position;

        Vector3 randomDiraction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0); //random diraction that enemy will spawn

        Vector3 offScreenPosition = playerPosition + (randomDiraction.normalized * spawnOffset); // position that enemy will spawn

        return offScreenPosition;
    }

    void CheckSpawnValue()
    {
        foreach(EnemySet enemySetTemp in enemySet)
        {
            foreach(EnemySetDetail enemySetDetail in enemySetTemp.enemySetDetail)
            {
                if(gameTime % enemySetDetail.enemySpawnTime == 0)
                {
                    for (int i = 0; i < enemySetDetail.enemySpawnCount ; i++)
                    {
                        SpawnEnemyFromPool(enemySetDetail.enemyTag);
                    }
                }
            }
        }
    }

    void SpawnSequence()
    {
        CountTime();
        // CheckSpawnTime();
        CheckSpawnValue();
    }

    public void DestroyAllEnemy()
    {
        foreach(GameObject _enemy in enemyContainer)
        {
            _enemy.SetActive(false);
        }
    }
}
